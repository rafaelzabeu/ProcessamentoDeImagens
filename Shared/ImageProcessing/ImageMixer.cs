using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing
{
    public static class ImageMixer
    {
        public static Bitmap AlternatingPixels(Bitmap bit1, Bitmap bit2)
        {
            if (bit1.Width != bit2.Width || bit2.Height != bit1.Height)
                throw new Exception("The bitmaps must have the same width and height");

            Bitmap result = new Bitmap(bit1.Width, bit1.Height);

            BitmapData data1 = bit1.LockBits(new Rectangle(
                0, 0, bit1.Width, bit1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData data2 = bit2.LockBits(new Rectangle(
                0, 0, bit2.Width, bit2.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dataResult = result.LockBits(new Rectangle(
                0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int pixelSize = 3;

                int width = bit1.Width;
                int height = bit1.Height;

                byte* row1 = (byte*)data1.Scan0;
                byte* row2 = (byte*)data2.Scan0;
                byte* rowResut = (byte*)dataResult.Scan0;

                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        int ptrIndex = (x * pixelSize) + (y * data1.Stride);

                        Color newColor = x % 2 == 0 ? GetColor(row1, ptrIndex) : GetColor(row2, ptrIndex);

                        rowResut[ptrIndex + 2] = (byte)newColor.R;
                        rowResut[ptrIndex + 1] = (byte)newColor.G;
                        rowResut[ptrIndex] = (byte)newColor.B;
                    }
                });
            }

            bit1.UnlockBits(data1);
            bit2.UnlockBits(data2);
            result.UnlockBits(dataResult);

            GC.Collect();

            return result;
        }

        public static Bitmap Blend(Bitmap bit1, double por1, Bitmap bit2, double por2)
        {
            if (bit1.Width != bit2.Width || bit2.Height != bit1.Height)
                throw new Exception("The bitmaps must have the same width and height");

            Bitmap result = new Bitmap(bit1.Width, bit1.Height);

            BitmapData data1 = bit1.LockBits(new Rectangle(
                0, 0, bit1.Width, bit1.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData data2 = bit2.LockBits(new Rectangle(
                0, 0, bit2.Width, bit2.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData dataResult = result.LockBits(new Rectangle(
                0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int pixelSize = 3;

                int width = bit1.Width;
                int height = bit1.Height;

                byte* row1 = (byte*)data1.Scan0;
                byte* row2 = (byte*)data2.Scan0;
                byte* rowResut = (byte*)dataResult.Scan0;

                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        int ptrIndex = (x * pixelSize) + (y * data1.Stride);

                        Color newColor = BlendColor(GetColor(row1, ptrIndex), por1, GetColor(row2, ptrIndex), por2);

                        rowResut[ptrIndex + 2] = (byte)newColor.R;
                        rowResut[ptrIndex + 1] = (byte)newColor.G;
                        rowResut[ptrIndex] = (byte)newColor.B;
                    }
                });
            }

            bit1.UnlockBits(data1);
            bit2.UnlockBits(data2);
            result.UnlockBits(dataResult);

            GC.Collect();

            return result;
        }

        public static Bitmap AlphaBlend(Bitmap bit1, Bitmap bit2)
        {
            if (bit1.Width != bit2.Width || bit2.Height != bit1.Height)
                throw new Exception("The bitmaps must have the same width and height");

            Bitmap result = new Bitmap(bit1.Width, bit1.Height);

            BitmapData data1 = bit1.LockBits(new Rectangle(
                0, 0, bit1.Width, bit1.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData data2 = bit2.LockBits(new Rectangle(
                0, 0, bit2.Width, bit2.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData dataResult = result.LockBits(new Rectangle(
                0, 0, result.Width, result.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                int pixelSize = 4;

                int width = bit1.Width;
                int height = bit1.Height;

                byte* row1 = (byte*)data1.Scan0;
                byte* row2 = (byte*)data2.Scan0;
                byte* rowResut = (byte*)dataResult.Scan0;

                //Parallel.For(0, height, y =>
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {

                        int ptrIndex = (x * pixelSize) + (y * data1.Stride);

                        Color newColor = BlendColorAlpha(GetColorAlpha(row1, ptrIndex), GetColorAlpha(row2, ptrIndex));

                        rowResut[ptrIndex + 3] = (byte)newColor.A;
                        rowResut[ptrIndex + 2] = (byte)newColor.R;
                        rowResut[ptrIndex + 1] = (byte)newColor.G;
                        rowResut[ptrIndex] = (byte)newColor.B;

                    }
                };
            }

            bit1.UnlockBits(data1);
            bit2.UnlockBits(data2);
            result.UnlockBits(dataResult);

            GC.Collect();

            return result;
        }

        private static unsafe Color GetColor(byte* row, int ptrIndex)
        {
            int r = (int)row[ptrIndex + 2];
            int g = (int)row[ptrIndex + 1];
            int b = (int)row[ptrIndex];

            return Color.FromArgb(r, g, b);
        }

        private static unsafe Color GetColorAlpha(byte* row, int ptrIndex)
        {
            int a = row[ptrIndex + 3];
            int r = row[ptrIndex + 2];
            int g = row[ptrIndex + 1];
            int b = row[ptrIndex];
            return Color.FromArgb(a, r, g, b);
        }

        private static unsafe Color BlendColor(Color c1, double value1, Color c2, double value2)
        {
            int r = (int)(c1.R * value1 + c2.R * value2);
            int g = (int)(c1.G * value1 + c2.G * value2);
            int b = (int)(c1.B * value1 + c2.B * value2);
            return Color.FromArgb(r, g, b);
        }

        private static unsafe Color BlendColorAlpha(Color c1, Color c2)
        {
            double a1 = c1.A / 255;
            int r = MathExtensions.Clamp((int)((c1.R * a1) + (c2.R * (1 - a1))), 0, 255);
            int g = MathExtensions.Clamp((int)((c1.G * a1) + (c2.G * (1 - a1))), 0, 255);
            int b = MathExtensions.Clamp((int)((c1.B * a1) + (c2.B * (1 - a1))), 0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
