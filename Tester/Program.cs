using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.ColorTypes;

namespace Tester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while(true)
            {
                string s = Console.ReadLine();
                string[] sS = s.Split(' ');

                byte[] d = new byte[3];

                d[0] = byte.Parse(sS[0]);
                d[1] = byte.Parse(sS[1]);
                d[2] = byte.Parse(sS[2]);

                HSLPixel pixel = new HSLPixel(d[0], d[1], d[2]);

                Console.WriteLine("HSL " + pixel.H + " " + pixel.S + " " + pixel.L);
                Console.WriteLine("Pretty HSL " + pixel.PrettyH + " " + pixel.PrettyL + " " + pixel.PrettyS);
                Color c = pixel.ToColor();

                Console.WriteLine("RGB " + c.R + " " + c.G + " " + c.B + "\n");
                

            }
        }
    }
}
