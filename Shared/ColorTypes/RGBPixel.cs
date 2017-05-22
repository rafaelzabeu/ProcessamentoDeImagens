using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ColorTypes
{
    /// <summary>
    /// Represents a pixel in RBG format and has methods for manipulating it.
    /// </summary>
    public class RGBPixel
    {
        private const double RED_WEIGHT = 0.299;
        private const double GREEN_WEIGHT = 0.587;
        private const double BLUE_WEIGHT = 0.114;

        /// <summary>
        /// Types of gray scale calculations.
        /// </summary>
        public enum GrayScaleTypes
        {
            /// <summary>
            /// Simple avarage calculation.
            /// </summary>
            Avarage,
            /// <summary>
            /// Avarage calculation using weights.
            /// </summary>
            WeightedAverage
        }

        public byte Red { get { return m_color.R; } }
        public byte Green { get { return m_color.G; } }
        public byte Blue { get { return m_color.B; } }

        private Color m_color;

        public RGBPixel(Color c)
        {
            m_color = c;
        }

        public Color ToColor()
        {
            return m_color;
        }

        public Color ToGrayScale(GrayScaleTypes grayScaleType)
        {
            switch (grayScaleType)
            {
                case GrayScaleTypes.WeightedAverage:
                    return ToGrayScale(m_color, grayScaleType);
                case GrayScaleTypes.Avarage:
                default:
                    return ToGrayScale(m_color, GrayScaleTypes.Avarage);
            }
        }

        public static Color ToGrayScale(Color color, GrayScaleTypes type)
        {
            switch (type)
            {
                case GrayScaleTypes.WeightedAverage:
                    int c = (int)((color.R * RED_WEIGHT) + (color.G * GREEN_WEIGHT) + (color.B * BLUE_WEIGHT));
                    return Color.FromArgb(c, c, c);
                case GrayScaleTypes.Avarage:
                default:
                    int value = (color.R + color.G + color.B) / 3;
                    return Color.FromArgb(value, value, value);
            }
        }

        public static Color InvertContrast(Color c)
        {
            return Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B);
        }
    }
}
