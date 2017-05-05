using ProcessamentoDeImagens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;

namespace Lista2
{
    public partial class Lista2 : Form
    {
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

        public Lista2()
        {
            InitializeComponent();
        }

        private void btn_exe1_Click(object sender, EventArgs e)
        {

        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Form f = new Exercicio2();
            m_openForms.Add(f);
            f.ShowDialog();
        }
    }
}
