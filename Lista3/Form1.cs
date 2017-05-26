using ProcessamentoDeImagens;
using Shared;
using Shared.ColorTypes;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Form> m_openForms = new List<Form>();

        private void closeOtherExercises()
        {
            foreach (var item in m_openForms)
            {
                item.Close();
            }
            m_openForms.Clear();
        }

        private void CreateView(string name, Bitmap image)
        {
            m_openForms.Add(ViewBuilder.BuildImageView(name, image));
        }

        private void btn_exe1_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Exercicio1 exc1 = new Exercicio1();

            exc1.Show();
            m_openForms.Add(exc1);

        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Bitmap orig = ImageGetter.GetImageFromUser();

            if (orig == null)
                return;

            Bitmap cha = orig.InvertContrast();

            CreateView("Orig", orig);
            CreateView("Changed", cha);

        }

        private void btn_exe3_Click(object sender, EventArgs e)
        {
            Bitmap image = ImageGetter.GetImageFromUser();

            if (image == null)
                return;

            Histogram histo = new Histogram(image.ToGrayScale());

            Bitmap eq = histo.MakeEqualizedVersion();

            CreateView("Eq", eq);

        }

        private void btn_exe4_Click(object sender, EventArgs e)
        {
            Bitmap bit = ImageGetter.GetImageFromUser();
            if (bit == null)
                return;

            //Bitmap after = BitmapUtils.Limiarize(bit, 225);

            BlobFinder finder = new BlobFinder();


            var v = finder.Find(bit);

            CreateView("Imagem limiarizada",BitmapUtils.Limiarize(bit, 225));
            MessageBox.Show($"Existem {v} objetos distintos na imagem", "Exercicio 4", MessageBoxButtons.OK);

        }
    }
}
