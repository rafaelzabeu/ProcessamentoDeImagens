using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class BitmapUtils
    {
        public static Bitmap Transform(Bitmap source, Func<int, int, Color, Color> operation)
        {
            Bitmap target = new Bitmap(source);

            unsafe
            {
                Rectangle rec = new Rectangle(0, 0, source.Width, source.Height);
                BitmapData sourceData = source.LockBits(rec, ImageLockMode.ReadWrite, source.PixelFormat);
                BitmapData targetData = target.LockBits(rec, ImageLockMode.ReadWrite, target.PixelFormat);

                int bytesPerPixel = Bitmap.GetPixelFormatSize(source.PixelFormat) / 8;
                int heightInPixels = source.Height;
                int widthInBytes = sourceData.Width * bytesPerPixel;

                byte* prtSource = (byte*)sourceData.Scan0.ToPointer();
                byte* prtTarget = (byte*)targetData.Scan0.ToPointer();


            }

            return target;
        }

        /// <summary>
        /// Retuns an array of the separated RGB componets of the bitmap.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>Array of size 3 with the R,G and B bitmaps respectvely</returns>
        public static Bitmap[] SeparateRGB(Bitmap source)
        {
            Bitmap[] results = new Bitmap[3];

            results[0] = source.Clone() as Bitmap;
            results[1] = source.Clone() as Bitmap;
            results[2] = source.Clone() as Bitmap;

            PixelsData data = source.GetAllPixels();

            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                results[0].SetEachPixel((column, row) =>
                {
                    byte r = data.red[column][row];
                    return Color.FromArgb(r, r, r);
                });
            });

            tasks[1] = Task.Run(() =>
            {
                results[1].SetEachPixel((column, row) =>
                {
                    byte b = data.blue[column][row];
                    return Color.FromArgb(b, b, b);
                });
            });

            tasks[2] = Task.Run(() =>
            {
                results[2].SetEachPixel((column, row) =>
                {
                    byte g = data.green[column][row];
                    return Color.FromArgb(g, g, g);
                });
            });

            Task.WaitAll(tasks);

            return results;
        }


        /// <summary>
        /// Separtes the passed bitmap in its CMY components.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>A bitmap array of size 3 with the C, M and Y components respectvely</returns>
        public static Bitmap[] SeparateCMY(Bitmap source)
        {
            Bitmap[] results = new Bitmap[3];

            results[0] = source.Clone() as Bitmap;
            results[1] = source.Clone() as Bitmap;
            results[2] = source.Clone() as Bitmap;

            PixelsData data = source.GetAllPixels();

            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                results[0].SetEachPixel((column, row) =>
                {
                    byte c = (byte)(255 - (data.red[column][row]));
                    return Color.FromArgb(c, c, c);
                });
            });

            tasks[1] = Task.Run(() =>
            {
                results[1].SetEachPixel((column, row) =>
                {
                    byte m = (byte)(255 - (data.green[column][row]));
                    return Color.FromArgb(m, m, m);
                });
            });

            tasks[2] = Task.Run(() =>
            {
                results[2].SetEachPixel((column, row) =>
                {
                    byte y = (byte)(255 - (data.blue[column][row]));
                    return Color.FromArgb(y, y, y);
                });
            });

            Task.WaitAll(tasks);

            return results;
        }

        //TODO Fix conversion, time function
        public static Bitmap HSLTransform(Bitmap source, Func<float[], float[]> transformation)
        {
            Bitmap result = source.Clone() as Bitmap;

            PixelsData data = source.GetAllPixels();


            PixelsData d = new PixelsData(data.red.Length);

            int height = data.red.Length;
            int widht = data.red[0].Length;

            for (int column = 0; column < height; column++)
            {
                d.red[column] = new byte[widht];
                d.blue[column] = new byte[widht];
                d.green[column] = new byte[widht];

                for (int row = 0; row < widht; row++)
                {
                    float[] hsl = RGBToHSL(data.red[column][row], data.green[column][row], data.blue[column][row]);

                    hsl = transformation(hsl);

                    byte[] rgb = HSLToRGB(hsl[0], hsl[1], hsl[2]);

                    d.red[column][row] = rgb[0];
                    d.green[column][row] = rgb[1];
                    d.blue[column][row] = rgb[2];

                }
            }


            result.SetEachPixel((column, row) =>
            {
                return Color.FromArgb(d.red[column][row], d.green[column][row], d.blue[column][row]);
            });

            return result;

        }

        private static float[] RGBToHSL(byte R, byte G, byte B)
        {
            float red = R / 255;
            float blue = G / 255;
            float green = B / 255;

            float maxValue = max(red, blue, green);
            float minValue = min(red, blue, green);

            float deltMax = maxValue - minValue;

            float l = (maxValue + minValue) / 2;
            float h = 0;
            float s = 0;

            if (deltMax == 0)
            {
                h = 0;
                s = 0;
            }
            else
            {
                if (l < 0.5)
                    s = deltMax / (maxValue + minValue);
                else
                    s = deltMax / (2 - maxValue - minValue);

                float delR = (((maxValue - red) / 6) + (deltMax / 2)) / deltMax;
                float delG = (((maxValue - green) / 6) + (deltMax / 2)) / deltMax;
                float delB = (((maxValue - blue) / 6) + (deltMax / 2)) / deltMax;

                if (red == maxValue)
                    h = delB - delG;
                else if (green == maxValue)
                    h = (1 / 3) + delR - delB;
                else if (blue == maxValue)
                    h = (2 / 3) + delG - delR;

                if (h < 0)
                    h += 1;
                if (h > 1)
                    h -= 1;

            }

            return new float[] { h, l, s };

        }

        private static byte[] HSLToRGB(float h, float s, float l)
        {
            byte r, g, b;
            if (s == 0)
            {
                r = (byte)(l * 255);
                g = r;
                b = r;
            }
            else
            {
                float aux2, aux1;
                if (l < 0.5f)
                    aux2 = l * (1 + s);
                else
                    aux2 = (l + s) - (s * l);

                aux1 = 2 * l - aux2;

                r = (byte)(255 * hueToRGB(aux1, aux2, h + (1 / 3)));
                g = (byte)(255 * hueToRGB(aux1, aux2, h));
                b = (byte)(255 * hueToRGB(aux1, aux2, h - (1 / 3)));
            }

            return new byte[] { r, g, b };
        }

        private static float hueToRGB(float v1, float v2, float vh)
        {
            if (vh < 0)
                vh += 1;
            if (vh > 0)
                vh -= 1;

            if ((6 * vh) < 1)
                return v1 + (v2 - v1) * 6 * vh;
            if ((2 * vh) < 1)
                return v2;
            if ((3 * vh) < 2)
                return v1 + (v2 - v1) * ((2 / 3) - vh) * 6;
            return v1;
        }

        private static float max(params float[] numbers)
        {
            float maxResult = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxResult)
                    maxResult = numbers[i];
            }

            return maxResult;
        }

        private static float min(params float[] numbers)
        {
            float minResult = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < minResult)
                    minResult = numbers[i];
            }
            return minResult;
        }

    }

}
