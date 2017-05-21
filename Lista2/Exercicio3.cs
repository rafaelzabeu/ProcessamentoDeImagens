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

namespace Lista2
{
    public partial class Exercicio3 : Form
    {
        public Exercicio3()
        {
            InitializeComponent();
        }

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
            Bitmap b = ImageGetter.GetImageFromUser();
            if (b == null)
                return;

            chartR.Series[0].Points.Clear();
            chartG.Series[0].Points.Clear();
            chartB.Series[0].Points.Clear();
            Histogram histo = new Histogram(b);
            for (int i = 0; i < 256; i++)
            {
                chartR.Series[0].Points.AddXY(i, histo.Red[i]);
                chartG.Series[0].Points.AddXY(i, histo.Green[i]);
                chartB.Series[0].Points.AddXY(i, histo.Blue[i]);
            }
        }
    }
}
