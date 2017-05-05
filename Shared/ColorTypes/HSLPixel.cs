using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ColorTypes
{
    public class HSLPixel
    {
        //TODO: Limit HSL values.
        public double H;
        public double S;
        public double L;

        public double PrettyH
        {
            get
            {
                double h = H * 60;
                if (h < 0)
                    h += 360d;
                return h;
            }
        }

        public double PrettyS
        {
            get
            {
                return S * 100d;
            }
        }

        public double PrettyL
        {
            get
            {
                return L * 100d;
            }
        }

        public HSLPixel(Color color)
        {
            new HSLPixel(color.R, color.G, color.B);
        }

        public HSLPixel(byte red, byte green, byte blue)
        {
            double[] v = rgbToHsl(red, green, blue);
            H = v[0];
            S = v[1];
            L = v[2];
        }

        public Color ToColor()
        {
            return hslToRgb(H, S, L);
        }

        private double[] rgbToHsl(byte _r, byte _g, byte _b)
        {
            double red, green, blue;
            red = (double)(_r / 255.0);
            green = (double)(_g / 255.0);
            blue = (double)(_b / 255.0);

            double max = Math.Max(Math.Max(red, green), blue);
            double min = Math.Min(Math.Min(red, green), blue);

            double d = max - min;

            double h = 0, s = 0, l = (max + min) / 2.0;

            if (d != 0)
            {
                if (l < 0.5)
                {
                    s = (d / (max + min));
                }
                else
                {
                    s = (d / (2.0 - max - min));
                }

                if (red == max)
                {
                    h = (green - blue) / d;
                }
                else if (green == max)
                {
                    h = 2.0 + (blue - red) / d;
                }
                else if (blue == max)
                {
                    h = 4.0 + (red - green) / d;
                }
            }

            return new double[] { h, s, l };
        }

        private Color hslToRgb(double h, double s, double l)
        {
            byte r, g, b;
            if (s == 0)
            {
                r = (byte)Math.Round(l * 255d);
                g = r;
                b = r;
            }
            else
            {
                double t1, t2;
                double th = h / 6d;

                if(l < 0.5)
                {
                    t2 = l * (1d + s);
                }
                else
                {
                    t2 = (l + s) - (l * s);
                }
                t1 = 2d * l - t2;

                double tr, tg, tb;
                tr = th + (1d / 3d);
                tg = th;
                tb = th - (1d / 3d);

                tr = ColorCalc(tr, t1, t2);
                tg = ColorCalc(tg, t1, t2);
                tb = ColorCalc(tb, t1, t2);
                r = (byte)Math.Round(tr * 255d);
                g = (byte)Math.Round(tg * 255d);
                b = (byte)Math.Round(tb * 255d);
            }

            return Color.FromArgb(r, g, b);
        
        }

        private double ColorCalc(double c, double t1, double t2)
        {
            if (c < 0) c += 1d;
            if (c > 1) c -= 1d;
            if (6d * c < 1d) return t1 + (t2 - t1) * 6d * c;
            if (2d * c < 1d) return t2;
            if (3d * c < 2d) return t1 + (t2 - t1) * (2d / 3d - c) * 6d;
            return t1;
        }

    }
}
