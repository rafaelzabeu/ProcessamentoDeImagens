﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessamentoDeImagens
{
    public static class ViewBuilder
    {
        public static Form BuildImageView(string formTitle, Bitmap image)
        {
            Form form = new Form();
            
            form.Text = formTitle;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Image = image;
            pictureBox.Size = image.Size;
            form.Controls.Add(pictureBox);
            form.AutoSize = true;

            form.Show();

            return form;
        }
    }
}
