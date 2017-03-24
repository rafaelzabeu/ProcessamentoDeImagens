using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Bitmap bitmap = ImageGetter.GetImageFromUser();

            Shared.BitmapPixels pixels = bitmap.GetAllPixels();

            bitmap.ForEachPixel((i, j, c) =>
            {
                Console.Write("GetAll: " + pixels.red[i][j] + " " + pixels.blue[i][j] + " " + pixels.green[i][j]);
                Console.WriteLine(" GetPixel: " + c.R + " " + c.B + " " + c.G);
            });
        }
    }
}
