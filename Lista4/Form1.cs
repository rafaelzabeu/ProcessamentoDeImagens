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
            Bitmap b1 = ImageGetter.GetImageFromUser();
            Bitmap b2 = ImageGetter.GetImageFromUser();

            if (b1 == null || b2 == null)
                return;

            Bitmap result = ImageMixer.AlternatingPixels(b1, b2);

            CreateView("", b1);
            CreateView("", b2);
            CreateView("Mix", result);

        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Exercicio1 ex = new Exercicio1();
            ex.Show();
            m_openForms.Add(ex);
        }

        private void btn_exe3_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Bitmap b1 = ImageGetter.GetImageFromUser();
            Bitmap b2 = ImageGetter.GetImageFromUser();

            if (b1 == null || b2 == null)
                return;

            Bitmap result = ImageMixer.AlphaBlend(b1, b2);

            CreateView("", b1);
            CreateView("", b2);
            CreateView("Mix", result);
        }
    }
}
