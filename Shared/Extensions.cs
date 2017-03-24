using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class Extensions
    {
        /// <summary>
        /// Iterates througt all pixels of the bitmap.
        /// Slow.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="forEach"></param>
        public static void ForEachPixel(this Bitmap bitmap, Action<int, int, Color> forEach)
        {
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    forEach(i, j, bitmap.GetPixel(i, j));
                }
            }
        }

        /// <summary>
        /// Iterates througt all pixels of the bitmap.
        /// Faster, locks bitmap bits.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="forEach">colum, row, blue, green, red</param>
        public static void GetEachPixel(this Bitmap bitmap, Action<int, int, byte, byte, byte> forEach)
        {
            //Area of the image to lock(all of it)
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //Lock the image so no one can change it, but any one can read
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //Address of the first line of pixels
            IntPtr ptr = data.Scan0;

            //Makes an array to hold the pixel info
            int bytes = data.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            //Copys the pixel info to the array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            //Keeps the info of the bitmap, so we can find the pixels in the array
            int stride = data.Stride;
            int height = data.Height;
            int width = data.Width;

            //The needed info is copied to the array, so unlock the bitmap
            bitmap.UnlockBits(data);

            for (int column = 0; column < height; column++)
            {
                for (int row = 0; row < width; row++)
                {
                    byte blue = rgbValues[(column * stride) + (row * 3)];
                    byte green = rgbValues[(column * stride) + (row * 3) + 1];
                    byte red = rgbValues[(column * stride) + (row * 3) + 2];
                    forEach(column, row, blue, green, red);
                }
            }
        }

        public static void SetEachPixel(this Bitmap bitmap, Func<int, int, Color> forEach)
        {
            //Area of the image to lock(all of it)
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //Lock the image so no one can change it, but any one can read
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //Address of the first line of pixels
            IntPtr ptr = data.Scan0;

            //Makes an array to hold the pixel info
            int bytes = data.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            //Copys the pixel info to the array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            //Keeps the info of the bitmap, so we can find the pixels in the array
            int stride = data.Stride;
            int height = data.Height;
            int width = data.Width;

            for (int column = 0; column < height; column++)
            {
                for (int row = 0; row < width; row++)
                {
                    Color c = forEach(column, row);
                    rgbValues[(column * stride) + (row * 3)] = c.R;
                    rgbValues[(column * stride) + (row * 3) + 1] = c.B;
                    rgbValues[(column * stride) + (row * 3) + 2] = c.G;
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(rgbValues,0,ptr,rgbValues.Length);

            bitmap.UnlockBits(data);
        }

        public static PixelsData GetAllPixels(this Bitmap bitmap)
        {
            //Area of the image to lock(all of it)
            Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            //Lock the image so no one can change it, but any one can read
            BitmapData data = bitmap.LockBits(rect, ImageLockMode.ReadWrite, bitmap.PixelFormat);

            //Address of the first line of pixels
            IntPtr ptr = data.Scan0;

            //Makes an array to hold the pixel info
            int bytes = data.Stride * bitmap.Height;
            byte[] rgbValues = new byte[bytes];

            //Copys the pixel info to the array
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

            //Keeps the info of the bitmap, so we can find the pixels in the array
            int stride = data.Stride;
            int height = data.Height;
            int width = data.Width;

            //The needed info is copied to the array, so unlock the bitmap
            bitmap.UnlockBits(data);

            PixelsData pixData = new PixelsData(height);


            for (int column = 0; column < height; column++)
            {
                pixData.red[column] = new byte[width];
                pixData.blue[column] = new byte[width];
                pixData.green[column] = new byte[width];

                for (int row = 0; row < width; row++)
                {

                    pixData.blue[column][row] = rgbValues[(column * stride) + (row * 3)];
                    pixData.green[column][row] = rgbValues[(column * stride) + (row * 3) + 1];
                    pixData.red[column][row] = rgbValues[(column * stride) + (row * 3) + 2];
                }
            }

            return pixData;
        }

    }

    public struct PixelsData
    {
        public byte[][] red;
        public byte[][] blue;
        public byte[][] green;

        public PixelsData(int height)
        {
            red = new byte[height][];
            blue = new byte[height][];
            green = new byte[height][];
        }

    }

}
