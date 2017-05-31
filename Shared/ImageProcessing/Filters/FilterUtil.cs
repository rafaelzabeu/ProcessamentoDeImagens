using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterUtil
    {
        public static Bitmap Filter(Bitmap original, IFilter filter)
        {
            return Transform(original, filter.MaskSize, filter.GetColor);
        }

        private static Bitmap Transform(Bitmap original, int filterSize, Func<Color[,], Color> transform)
        {
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            BitmapData originalData = original.LockBits(new Rectangle(
                0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData newData = newImage.LockBits(new Rectangle(
                0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int PixelSize = 3;

                //Get the pointer to the start of the images
                byte* originalRow = (byte*)originalData.Scan0;
                byte* newRow = (byte*)newData.Scan0;

                int width = original.Width;
                int height = original.Height;

                //Each line of the bitmap can be read and edited in parallel
                //having the outer for being height is more efficient due how the bitmap data is structured
                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        //find our pixel in the memory
                        int ptrIndex = (x * PixelSize) + (y * originalData.Stride);

                        Color[,] filter = new Color[filterSize, filterSize];

                        for (int xx = 0; xx < filterSize; xx++)
                        {
                            for (int yy = 0; yy < filterSize; yy++)
                            {
                                if (IsValidCoordinate(x + xx, y + yy, width, height))
                                {
                                    filter[xx, yy] = GetColor(originalRow, originalData.Stride, PixelSize, x + xx, y + yy);
                                }
                                else
                                {
                                    filter[xx, yy] = GetColor(originalRow, originalData.Stride, PixelSize, x, y);
                                }
                            }
                        }

                        Color newColor = transform(filter);

                        //set the new color in the bitmap to be returned
                        newRow[ptrIndex + 2] = (byte)newColor.R;
                        newRow[ptrIndex + 1] = (byte)newColor.G;
                        newRow[ptrIndex] = (byte)newColor.B;
                    }
                });
            }

            original.UnlockBits(originalData);
            newImage.UnlockBits(newData);

            GC.Collect();

            return newImage;
        }

        private unsafe static Color GetColor(byte* row, int stride, int pixelSize, int x, int y)
        {
            int ptrIndex = (x * pixelSize) + (y * stride);
            int r = (int)row[ptrIndex + 2];
            int g = (int)row[ptrIndex + 1];
            int b = (int)row[ptrIndex];

            return Color.FromArgb(r, g, b);
        }

        private static bool IsValidCoordinate(int x, int y, int width, int height)
        {
            return (x > -1 && x < width) && (y > -1 && y < height);
        }
    }
}
