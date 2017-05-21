﻿using Shared.ColorTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing
{
    public class Histogram 
    {
        public int[] Red { get; set; }
        public int[] Green { get; set; }
        public int[] Blue { get; set; }

        public Histogram(Bitmap bitmap)
        {
            Red = new int[256];
            Green = new int[256];
            Blue = new int[265];
            bitmap.ForEachPixel((color, x, y) =>
            {
                Red[color.R]++;
                Green[color.G]++;
                Blue[color.B]++;
            });
        }

    }
}