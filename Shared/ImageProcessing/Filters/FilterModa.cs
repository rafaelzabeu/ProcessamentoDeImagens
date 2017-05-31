using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public class FilterModa : IFilter
    {
        public int MaskSize
        {
            get
            {
                return m_maskSize;
            }
        }

        private int m_maskSize;

        public FilterModa(int maskSize)
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

            //sorts groups the equals values, sorts the groups counts by descending, and gets the value of the first one.
            //this gets the most frequent value of the reds list. LINQ is magical.
            int r = reds.GroupBy(x => x).OrderByDescending(value => value.Count()).Select(s => s.Key).First();
            int g = greens.GroupBy(x => x).OrderByDescending(value => value.Count()).Select(s => s.Key).First();
            int b = blues.GroupBy(x => x).OrderByDescending(value => value.Count()).Select(s => s.Key).First();

            return Color.FromArgb(r, g, b);
        }
    }
}
