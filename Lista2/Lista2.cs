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
using Shared.ColorTypes;

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
            closeOtherExercises();
            Exercicio1 one = new Exercicio1();
            one.Show();
            m_openForms.Add(one);
        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Exercicio2 exc2 = new Exercicio2();
            exc2.Show();
            m_openForms.Add(exc2);
        }

        private void btn_exe3_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Exercicio3 exc3 = new Exercicio3();
            exc3.Show();
            m_openForms.Add(exc3);
        }

        private void btn_exe4_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Bitmap bit = ImageGetter.GetImageFromUser();
            if (bit == null)
                return;


            double result = BitmapUtils.GetBritness(bit);

            string s;
            if (result > 128)
                s = "Clara";
            else if (result < 128)
                s = "Escura";
            else
                s = "Indefinida";

            Form form = new Form();
            Label label = new Label();
            label.Text = s;
            form.Controls.Add(label);
            form.ShowDialog();

        }

        private void btn_exc5_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Exercicio5 exec5 = new Exercicio5();
            exec5.Show();
            m_openForms.Add(exec5);
        }
    }
}
