using ProcessamentoDeImagens;
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
            m_openForms.Add(ImageViewBuilder.BuildImageView(name, image));
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
    }
}
