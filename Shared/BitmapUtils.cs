using Shared.ColorTypes;
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
        public static Bitmap HSLTransform(Bitmap source, Func<HSLPixel, Color> transformation)
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
                    HSLPixel hsl = new HSLPixel(data.red[column][row], data.green[column][row], data.blue[column][row]);

                    Color c = transformation(hsl);

                    d.red[column][row] = c.R;
                    d.green[column][row] = c.G;
                    d.blue[column][row] = c.B;

                }
            }


            result.SetEachPixel((column, row) =>
            {
                return Color.FromArgb(d.red[column][row], d.green[column][row], d.blue[column][row]);
            });

            return result;

        }

    }

}
