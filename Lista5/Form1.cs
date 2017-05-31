using ProcessamentoDeImagens;
using Shared;
using Shared.ImageProcessing.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Bitmap b = ImageGetter.GetImageFromUser();
            if (b == null)
                return;

            Bitmap b2 = FilterUtil.Filter(b, new FilterBorderDetection(3, FilterBorderDetection.FilterType.Sobel));
            Bitmap b3 = FilterUtil.Filter(b2, new FilterModa(3));

            CreateView("A", b);
            CreateView("B", b2);
            CreateView("C", b3);

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
    }
}
