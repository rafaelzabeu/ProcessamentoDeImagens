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
    public partial class Exercicio2 : Form
    {
        public Exercicio2()
        {
            InitializeComponent();
        }

        private void btn_loadImage_Click(object sender, EventArgs e)
        {
            Bitmap image = ImageGetter.GetImageFromUser();
            if (image == null)
                return;
            int limiar = Convert.ToInt32(string.IsNullOrWhiteSpace(txt_limiar.Text) ? "0" : txt_limiar.Text);

            Bitmap changed = image.Process((color, x, y) =>
            {
                Color c = RGBPixel.ToGrayScale(color, RGBPixel.GrayScaleTypes.WeightedAverage);
                if (c.R >= limiar)
                    return Color.White;
                else
                    return Color.Black;
            });

            Form f = ViewBuilder.BuildImageView("Imagem", changed);
            f.Visible = false;
            f.ShowDialog();
        }
    }
}
