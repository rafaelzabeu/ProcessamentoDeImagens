using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ColorTypes
{
    public class YUVPixel
    {

        public int Y;
        public int U;
        public int V;


        public YUVPixel(Color rgbColor)
        {
            Y = Clamp(((66 * rgbColor.R + 129 * rgbColor.G + 25 * rgbColor.B + 128) >> 8) + 16);
            U = Clamp(((-38 * rgbColor.R - 74 * rgbColor.G + 112 * rgbColor.B + 128) >> 8) + 128);
            V = Clamp(((112 * rgbColor.R - 94 * rgbColor.G - 18 * rgbColor.B + 128) >> 8) + 128);
        }

        public Color ToColor()
        {
            int C = this.Y - 16;
            int D = this.U - 128;
            int E = this.V - 128;
            return Color.FromArgb(
                Clamp((298 * C + 409 * E + 128) >> 8),
                Clamp((298 * C - 100 * D - 208 * E + 128) >> 8),
                Clamp((298 * C + 516 * D + 128) >> 8));
        }



        private int Clamp(int value)
        {
            if (value > 255)
                return 255;
            if (value < 0)
                return 0;
            return value;
        }

    }
}
