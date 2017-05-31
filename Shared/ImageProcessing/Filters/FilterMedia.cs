using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterMedia : IFilter
    {
        public int MaskSize
        {
            get
            {
                return m_maskSize;
            }
        }

        private int m_maskSize;

        private double m_numOfMaskElements;

        public FilterMedia(int maskSize)
        {
            m_maskSize = maskSize;
            m_numOfMaskElements = m_maskSize * m_maskSize;
        }

        public Color GetColor(Color[,] colors)
        {
            int r = 0;
            int g = 0;
            int b = 0;
            for (int x = 0; x < m_maskSize; x++)
            {
                for (int y = 0; y < m_maskSize; y++)
                {
                    Color c = colors[x, y];
                    r += c.R;
                    g += c.G;
                    b += c.B;
                }
            }

            r = (int)MathExtensions.Clamp(r / m_numOfMaskElements, 0, 255);
            g = (int)MathExtensions.Clamp(g / m_numOfMaskElements, 0, 255);
            b = (int)MathExtensions.Clamp(b / m_numOfMaskElements, 0, 255);

            return Color.FromArgb(r, g, b);
        }
    }
}
