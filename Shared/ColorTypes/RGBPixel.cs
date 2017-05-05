using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ColorTypes
{
    public class RGBPixel
    {
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
    }
}
