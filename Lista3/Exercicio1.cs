using Shared;
using Shared.ImageProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista3
{
    public partial class Exercicio1 : Form
    {
        public Exercicio1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;

            Histogram origHisto = new Histogram(orig.ToGrayScale());

            Bitmap chang = orig.Process((color, x, y) =>
            {
                int r = Clamp((color.R + 50), 0, 255);
                int b = Clamp((color.B + 50), 0, 255);
                int g = Clamp((color.G + 50), 0, 255);

                return Color.FromArgb(r, g, b);

            });

            Histogram changHisto = new Histogram(chang.ToGrayScale());

            origHisto.FillGraph(graphOrig);
            changHisto.FillGraph(graphChang);

            img_orig.Image = orig;
            img_orig.SizeMode = PictureBoxSizeMode.StretchImage;
            img_chang.Image = chang;
            img_chang.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private int Clamp(int value, int minValue, int maxValue)
        {
            if (value < minValue)
                value = minValue;
            if (value > maxValue)
                value = maxValue;
            return value;
        }

    }
}
