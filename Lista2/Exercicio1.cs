using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista2
{
    public partial class Exercicio1 : Form
    {
        public Exercicio1()
        {
            InitializeComponent();
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            double analog = new Random().NextDouble() * 10;

            int size = Convert.ToInt32(txt_size.Text);

            int maxValue = (int)Math.Pow(2, size);

            double step = (10d / ((double)maxValue - 1));

            double filterMin = Convert.ToDouble(string.IsNullOrEmpty(textBox1.Text) ? "0" : textBox1.Text);
            double filterMax = Convert.ToDouble(string.IsNullOrEmpty(textBox2.Text) ? "0" : textBox2.Text);

            //Apply filter
            switch (comboBox1.Text)
            {
                case "Passa Baixa":
                    if (analog > filterMin)
                        analog = filterMin;
                    break;
                case "Passa Alta":
                    if (analog < filterMin)
                        analog = filterMin;
                    break;
                case "Passa Faixa":
                    if (analog < filterMin)
                        analog = filterMin;
                    if (analog > filterMax)
                        analog = filterMax;
                    break;
                case "Rejeita Faixa":
                    if (analog >= filterMin && analog <= filterMax)
                        analog = 0;
                    break;
                default:
                    break;
            }

            lbl_analog.Text = analog.ToString();

            int result = (int)(analog / step);
            lbl_number.Text = result.ToString();
            lbl_binary.Text = Convert.ToString(result, 2);
        }
    }
}
