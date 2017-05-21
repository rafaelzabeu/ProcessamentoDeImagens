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
    /// <summary>
    /// Defines extensions methods for the System.Drawing.Bitmap class.
    /// </summary>
    public static class BitmapExtensions
    {
        /// <summary>
        /// Returns a new bitmap based on the passed bitmap.
        /// The transform Func is called for each pixel of the original bitmap and its return is
        /// writen on the new bitmap.
        /// This function locks the passed bitmap for reading and writing.
        /// This function contains unsafe code.
        /// </summary>
        /// <param name="original">The bitmap to read and process</param>
        /// <param name="transform">A delegate that receives the Color of a pixel and its coordinates(width, heigth)
        /// and returns a new color for that pixel</param>
        /// <returns>The processed version of the passed bitmap</returns>
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

                        //get its colors, stored in memory as BGR
                        int r = (int)originalRow[ptrIndex + 2];
                        int g = (int)originalRow[ptrIndex + 1];
                        int b = (int)originalRow[ptrIndex];

                        //transform it according to the passed Func
                        Color novaCor = transform(Color.FromArgb(r, g, b), x, y);

                        //set the new color in the bitmap to be returned
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

        /// <summary>
        /// Iterates througt every pixel of the bitmap.
        /// This function locks the passed bitmap for reading and writing.
        /// This function contains unsafe code.
        /// </summary>
        /// <param name="bitmap">The bitmap to read.</param>
        /// <param name="forEach">A delegate that receives the Color of a pixel and its coordinates(width, height)</param>
        public static void ForEachPixel(this Bitmap bitmap, Action<Color,int,int> forEach)
        {
            BitmapData data = bitmap.LockBits(new Rectangle(
                0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                int pixelSize = 3;

                byte* row = (byte*)data.Scan0;
                
                int width = bitmap.Width;
                int height = bitmap.Height;

                Parallel.For(0, height, y =>
                {
                    for (int x = 0; x < width; x++)
                    {
                        //find our pixel in the memory
                        int ptrIndex = (x * pixelSize) + (y * data.Stride);

                        //get its colors, stored in memory as BGR
                        int r = (int)row[ptrIndex + 2];
                        int g = (int)row[ptrIndex + 1];
                        int b = (int)row[ptrIndex];

                        //transform it according to the passed Func
                        forEach(Color.FromArgb(r, g, b), x, y);
                    }
                });

            }

        }

        /// <summary>
        /// Returns the passed bitmap in grayscale.
        /// This function locks the passed bitmap for reading and writing.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="grayScaleType">Type of gray scale transformation to use</param>
        /// <returns></returns>
        public static Bitmap ToGrayScale(this Bitmap original, RGBPixel.GrayScaleTypes grayScaleType = RGBPixel.GrayScaleTypes.WeightedAverage)
        {
            return original.Process((color, x, y) => {
                return RGBPixel.ToGrayScale(color,grayScaleType);
            });
        }
    }
}
