using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterLineDetection : IFilter
    {
        public enum LineType
        {
            Horizontal,
            Vertical,
            MainDiagonal,
            SecondaryDiagonal
        }

        public LineType type;

        public int MaskSize
        {
            get
            {
                return m_maskSize;
            }
        }

        private int m_maskSize;
        private double[,] m_mask;

        public FilterLineDetection(int maskSize, LineType type)
        {
            m_maskSize = maskSize;
            this.type = type;
            m_mask = GetMask(m_maskSize, type);
        }

        public Color GetColor(Color[,] colors)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            for (int x = 0; x < m_maskSize; x++)
            {
                for (int y = 0; y < m_maskSize; y++)
                {
                    Color c = colors[x, y];
                    double value = m_mask[x, y];

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

        private double[,] GetMask(int size, LineType type)
        {
            double[,] mask = new double[size, size];
            int halfSize = size / 2;
            switch (type)
            {
                default:
                case LineType.Horizontal:
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            if (x == halfSize)
                                mask[x, y] = 2;
                            else
                                mask[x, y] = -1;
                        }
                    }
                    return mask;
                case LineType.Vertical:
                    for (int y = 0; y < size; y++)
                    {
                        for (int x = 0; x < size; x++)
                        {
                            if (y == halfSize)
                                mask[x, y] = 2;
                            else
                                mask[x, y] = -1;
                        }
                    }
                    return mask;
                case LineType.MainDiagonal:
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            if (x == y)
                                mask[x, y] = 2;
                            else
                                mask[x, y] = -1;
                        }
                    }
                    return mask;
                case LineType.SecondaryDiagonal:
                    for (int x = 0; x < size; x++)
                    {
                        for (int y = 0; y < size; y++)
                        {
                            if (x + y + 1 == size)
                                mask[x, y] = 2;
                            else
                                mask[x, y] = -1;
                        }
                    }
                    return mask;
            }
        }

    }
}
