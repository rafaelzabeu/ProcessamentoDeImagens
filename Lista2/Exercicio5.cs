using ProcessamentoDeImagens;
using Shared;
using Shared.ColorTypes;
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
    public partial class Exercicio5 : Form
    {
        public Exercicio5()
        {
            InitializeComponent();
        }

        private void bnt_loadImage_Click(object sender, EventArgs e)
        {
            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;
            int cut = Convert.ToInt32(string.IsNullOrWhiteSpace(txt_cut.Text) ? "0" : txt_cut.Text);
            if (cut > 255)
                cut = 255;
            if (cut < 0)
                cut = 0;

            Bitmap mod = orig.Process((color, x, y) => {
                Color c = RGBPixel.ToGrayScale(color, RGBPixel.GrayScaleTypes.WeightedAverage);

                if (c.R > cut)
                    return Color.Black;
                return c;
            });

            Form f = ViewBuilder.BuildImageView("Mud", mod);
            f.Visible = false;
            f.ShowDialog();

        }
    }
}
