using Shared.ColorTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Extensions
    {
        public static Bitmap Process(this Bitmap original, Func<Color,int, int, Color> transform)
        {
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            BitmapData originalData = original.LockBits(new Rectangle(
                0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData newData = newImage.LockBits(new Rectangle(
                0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int PixelSize = 3;

                byte* originalRow = (byte*)originalData.Scan0;
                byte* newRow = (byte*)newData.Scan0;

                int width = original.Width;
                int height = original.Height;

                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        int ptrIndex = (x * PixelSize) + (y * originalData.Stride);

                        int r = (int)originalRow[ptrIndex + 2];
                        int g = (int)originalRow[ptrIndex + 1];
                        int b = (int)originalRow[ptrIndex];

                        Color novaCor = transform(Color.FromArgb(r, g, b), x, y);

                        newRow[ptrIndex + 2] = (byte)novaCor.R;
                        newRow[ptrIndex + 1] = (byte)novaCor.G;
                        newRow[ptrIndex] = (byte)novaCor.B;
                    }
                });
            }

            original.UnlockBits(originalData);
            newImage.UnlockBits(newData);

            GC.Collect();

            return newImage;

        }

        public static Bitmap ToGrayScale(this Bitmap original)
        {
            return original.Process((color, x, y) => {
                int c = (int)((color.R * 0.299) + (color.G * 0.587) + (color.B * 0.114));
                return Color.FromArgb(c, c, c);
            });
        }

    }

}
