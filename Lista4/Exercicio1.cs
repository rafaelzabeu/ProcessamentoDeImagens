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

namespace Lista4
{
    public partial class Exercicio1 : Form
    {
        public Exercicio1()
        {
            InitializeComponent();
            FormClosing += Exercicio1_FormClosing;
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

        private void Exercicio1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeOtherExercises();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap b1 = ImageGetter.GetImageFromUser();
            Bitmap b2 = ImageGetter.GetImageFromUser();

            if (b1 == null || b2 == null)
                return;

            double por1 = Convert.ToDouble(txt_por1.Text)/ 100;
            double por2 = Convert.ToDouble(txt_por2.Text)/ 100;

            Bitmap result = ImageMixer.Blend(b1, por1, b2, por2);

            CreateView("", b1);
            CreateView("", b2);
            CreateView("Mix", result);

        }
    }
}
