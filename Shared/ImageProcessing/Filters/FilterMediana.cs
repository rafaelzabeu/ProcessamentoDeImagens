using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterMediana : IFilter
    {
        public int MaskSize
        {
            get
            {
                return m_maskSize;
            }
        }

        private int m_maskSize;

        public FilterMediana(int maskSize)
        {
            m_maskSize = maskSize;
        }

        public Color GetColor(Color[,] colors)
        {
            List<int> reds = new List<int>();
            List<int> greens = new List<int>();
            List<int> blues = new List<int>();


            for (int x = 0; x < m_maskSize; x++)
            {
                for (int y = 0; y < m_maskSize; y++)
                {
                    Color c = colors[x, y];
                    reds.Add(c.R);
                    greens.Add(c.G);
                    blues.Add(c.B);
                }
            }

            List<int> aux = reds.OrderBy(w => w).ToList();
            int r = aux[aux.Count / 2];

            aux = greens.OrderBy(w => w).ToList();
            int g = aux[aux.Count / 2];

            aux = blues.OrderBy(w => w).ToList();
            int b = aux[aux.Count / 2];

            return Color.FromArgb(r, g, b);
        }
    }
}
