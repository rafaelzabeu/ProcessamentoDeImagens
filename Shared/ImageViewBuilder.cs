using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessamentoDeImagens
{
    public static class ImageViewBuilder
    {
        public static Form BuildImageView(string formTitle, Bitmap image)
        {
            Form form = new Form();
            
            form.Text = formTitle;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.Image = image;
            pictureBox.Size = image.Size;
            form.Controls.Add(pictureBox);

            form.Show();

            return form;
        }
    }
}
