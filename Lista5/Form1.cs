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

        private void boxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var op = (string)boxFilter.Items[boxFilter.SelectedIndex];

            if (op == "Sobel")
            {
                boxSize.Items.Clear();
                boxSize.Items.Add("3x3");
                boxSize.Items.Add("5x5");
            }
            else
            {
                boxSize.Items.Clear();
                boxSize.Items.Add("3x3");
                boxSize.Items.Add("5x5");
                boxSize.Items.Add("7x7");
                boxSize.Items.Add("9x9");
            }

            boxSize.SelectedIndex = 0;
        }

        private bool IsGrayScale()
        {
            string op = (string)boxColor.Items[boxColor.SelectedIndex];
            switch (op)
            {

                default:
                case "Colorida":
                    return false;
                case "Preto e Branco":
                    return true;
            }
        }

        private int GetScale()
        {
            var op = (string)boxSize.Items[boxSize.SelectedIndex];
            switch (op)
            {
                case "3x3":
                default:
                    return 3;
                case "5x5":
                    return 5;
                case "7x7":
                    return 7;
                case "9x9":
                    return 9;
            }
        }

        private IFilter GetFilter(int size)
        {
            IFilter filterToUse;
            var op = (string)boxFilter.Items[boxFilter.SelectedIndex];
            switch (op)
            {
                default:
                case "Media":
                    filterToUse = new FilterMedia(size);
                    break;
                case "Mediana":
                    filterToUse = new FilterMediana(size);
                    break;
                case "Moda":
                    filterToUse = new FilterModa(size);
                    break;
                case "Linha Vertical":
                    filterToUse = new FilterLineDetection(size, FilterLineDetection.LineType.Vertical);
                    break;
                case "Linha Horizontal":
                    filterToUse = new FilterLineDetection(size, FilterLineDetection.LineType.Horizontal);
                    break;
                case "Linha Diagonal Principal":
                    filterToUse = new FilterLineDetection(size, FilterLineDetection.LineType.MainDiagonal);
                    break;
                case "Linha Diagonal Secundaria":
                    filterToUse = new FilterLineDetection(size, FilterLineDetection.LineType.SecondaryDiagonal);
                    break;
                case "Borda Normal":
                    filterToUse = new FilterBorderDetection(size, FilterBorderDetection.FilterType.Normal);
                    break;
                case "Sobel":
                    filterToUse = new FilterBorderDetection(size, FilterBorderDetection.FilterType.Sobel);
                    break;
            }
            return filterToUse;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;
            if (IsGrayScale())
                orig = orig.ToGrayScale();

            IFilter filterToUse = GetFilter(GetScale());

            Bitmap result = FilterUtil.Filter(orig, filterToUse);

            CreateView("Original", orig);
            CreateView("Result", result);
        }

    }
}
