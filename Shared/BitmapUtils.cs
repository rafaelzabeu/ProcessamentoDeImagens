using Shared.ColorTypes;
using Shared.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace Shared
{
    /// <summary>
    /// 
    /// </summary>
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

            results[0] = source.Process((color, x, y) =>
            {
                return Color.FromArgb(color.R, color.R, color.R);
            });

            results[1] = source.Process((color, x, y) =>
            {
                return Color.FromArgb(color.B, color.B, color.B);
            });

            results[2] = source.Process((color, x, y) =>
            {
                return Color.FromArgb(color.G, color.G, color.G);
            });

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

            results[0] = source.Process((color, column, row) =>
            {
                byte c = (byte)(255 - (color.R));
                return Color.FromArgb(c, c, c);
            });

            results[1] = source.Process((color, column, row) =>
            {
                byte c = (byte)(255 - (color.G));
                return Color.FromArgb(c, c, c);
            });


            results[2] = source.Process((color, column, row) =>
            {
                byte c = (byte)(255 - (color.B));
                return Color.FromArgb(c, c, c);
            });


            return results;
        }

        //TODO Fix conversion, time function
        public static Bitmap HSLTransform(Bitmap source, Func<HSLPixel, Color> transformation)
        {
            return source.Process((color, x, y) => {
                return transformation(new HSLPixel(color.R, color.G, color.B));
            });
        }

        public static Bitmap ChangePixelSize(Bitmap source, int bitSize)
        {
            double scale = Math.Pow(2, bitSize);
            double step = 255 / scale;

            return source.Process((color, x, y) =>
            {
                int r, g, b;
                r = (int)(Math.Round(scale * (color.R / 255d), MidpointRounding.AwayFromZero) * step);
                g = (int)(Math.Round(scale * (color.G / 255d), MidpointRounding.AwayFromZero) * step);
                b = (int)(Math.Round(scale * (color.B / 255d), MidpointRounding.AwayFromZero) * step);

                return Color.FromArgb(r, g, b);
            });

        }

        public static Bitmap ConvertToYUV422(Bitmap orig)
        {
            return orig.Process((color, x, y) =>
            {
                return new YUVPixel(color).ToColor();
            });
        }

        public static Bitmap ConvertToYUV420(Bitmap orig)
        {
            return orig.Process((color, x, y) =>
            {
                return new YUVPixel(color).ToColor();
            });
        }

        public static double GetBritness(Bitmap bitmap)
        {
            double sum = 0;

            bitmap.ForEachPixel((color, x, y) =>
            {
                Color c = RGBPixel.ToGrayScale(color, RGBPixel.GrayScaleTypes.WeightedAverage);
                sum += (c.R + c.G + c.B);
            });

            return Math.Floor(sum / (bitmap.Width * bitmap.Height));

        }

        public static Bitmap Limiarize(Bitmap orig, int limit)
        {
            return orig.Process((color, x, y) =>
            {
                Color c = RGBPixel.ToGrayScale(color, RGBPixel.GrayScaleTypes.WeightedAverage);
                if (c.R < limit)
                    return Color.Black;
                else
                    return Color.White;
            });
        }

        public static Bitmap FlipY(Bitmap original)
        {
            Bitmap newImage = new Bitmap(original.Width, original.Height);

            BitmapData originalData = original.LockBits(new Rectangle(
                0, 0, original.Width, original.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            BitmapData newData = newImage.LockBits(new Rectangle(
                0, 0, newImage.Width, newImage.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            unsafe
            {
                int PixelSize = 4;

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
                        int ptrIndexOrig = (x * PixelSize) + (y * originalData.Stride);
                        int ptrIndexNew = ((width - x - 1) * PixelSize) + ((height - y - 1) * newData.Stride);

                        //get its colors, stored in memory as BGR
                        byte a = originalRow[ptrIndexOrig + 3];
                        byte r = originalRow[ptrIndexOrig + 2];
                        byte g = originalRow[ptrIndexOrig + 1];
                        byte b = originalRow[ptrIndexOrig];

                        //set the new color in the bitmap to be returned
                        newRow[ptrIndexNew + 3] = a;
                        newRow[ptrIndexNew + 2] = r;
                        newRow[ptrIndexNew + 1] = g;
                        newRow[ptrIndexNew] = b;
                    }
                });
            }

            original.UnlockBits(originalData);
            newImage.UnlockBits(newData);

            GC.Collect();
            return newImage;
        }

    }

}
