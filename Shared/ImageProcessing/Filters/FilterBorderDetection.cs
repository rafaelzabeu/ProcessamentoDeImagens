using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterBorderDetection : IFilter
    {

        public enum FilterType
        {
            Normal,
            Sobel
        }

        public FilterType type;

        public int MaskSize
        {
            get
            {
                return m_maskSize;
            }
        }
        private int m_maskSize;

        private double[,] m_xMask;

        private double[,] m_yMask;

        public FilterBorderDetection(int maskSize, FilterType type)
        {
            this.type = type;
            m_maskSize = maskSize;
            if (type == FilterType.Normal)
                m_xMask = GetNormalMask(maskSize, type);
            else if (type == FilterType.Sobel)
                GetSobel(maskSize);
        }

        public Color GetColor(Color[,] colors)
        {
            switch (type)
            {
                default:
                case FilterType.Normal:
                    return filterNormal(colors);
                case FilterType.Sobel:
                    return filterSobel(colors);
            }
        }

        private Color filterNormal(Color[,] colors)
        {
            double r = 0;
            double g = 0;
            double b = 0;
            for (int x = 0; x < m_maskSize; x++)
            {
                for (int y = 0; y < m_maskSize; y++)
                {
                    Color c = colors[x, y];
                    double value = m_xMask[x, y];
                    r += c.R * value;
                    g += c.G * value;
                    b += c.B * value;
                }
            }

            r = MathExtensions.Clamp(r, 0, 255);
            g = MathExtensions.Clamp(g, 0, 255);
            b = MathExtensions.Clamp(b, 0, 255);

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private Color filterSobel(Color[,] colors)
        {
            double xR = 0, yR =0;
            double xG = 0, yG = 0;
            double xB = 0, yB = 0;

            for (int x = 0; x < m_maskSize; x++)
            {
                for (int y = 0; y < m_maskSize; y++)
                {
                    Color c = colors[x, y];
                    double xValue = m_xMask[x, y];
                    double yValue = m_yMask[x, y];

                    xR += c.R * xValue;
                    xG += c.G * xValue;
                    xB += c.B * xValue;

                    yR += c.R * yValue;
                    yG += c.G * yValue;
                    yB += c.B * yValue;
                }
            }

            double r = MathExtensions.Clamp(Math.Sqrt((xR * xR) + (yR * yR)), 0, 255);
            double g = MathExtensions.Clamp(Math.Sqrt((xG * xG) + (yG * yG)), 0, 255);
            double b = MathExtensions.Clamp(Math.Sqrt((xB * xB) + (yB * yB)), 0, 255);

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        private double[,] GetNormalMask(int size, FilterType type)
        {
            double[,] mask = new double[size, size];
            int halfSize = size / 2;


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mask[i, j] = -1;
                }
            }
            mask[halfSize, halfSize] = 8;
            return mask;

        }

        private void GetSobel(int size)
        {
            ResourceGetter.GetSobel(size, out m_xMask, out m_yMask);
        }

    }
}
