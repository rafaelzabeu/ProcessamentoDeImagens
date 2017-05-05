using Shared.ColorTypes;
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
                r = (int)(Math.Round(scale * color.R / 255.0, MidpointRounding.AwayFromZero) * step);
                g = (int)(Math.Round(scale * color.G / 255.0, MidpointRounding.AwayFromZero) * step);
                b = (int)(Math.Round(scale * color.B / 255.0, MidpointRounding.AwayFromZero) * step);

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

    }

}
