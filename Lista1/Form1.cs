using Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessamentoDeImagens
{
    public partial class Form1 : Form
    {
        private List<Form> m_openForms = new List<Form>();

        public Form1()
        {
            InitializeComponent();
        }

        private void closeOtherExercises()
        {
            foreach (var item in m_openForms)
            {
                item.Close();
            }
            m_openForms.Clear();
        }

        private void createView(string name, Bitmap image)
        {
            m_openForms.Add(ImageViewBuilder.BuildImageView(name, image));
        }

        private void btn_exe1_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Bitmap orig = ImageGetter.GetImageFromUser();

            if (orig == null)
                return;

            var stp = System.Diagnostics.Stopwatch.StartNew();

            Bitmap[] result = BitmapUtils.SeparateRGB(orig);

            stp.Stop();

            lbl_stp.Text = stp.Elapsed.ToString();
            createView("Red", result[0]);
            createView("Blue", result[1]);
            createView("Green", result[2]);
            createView("Original", orig);
        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;


            Bitmap orig2 = orig.Clone() as Bitmap;

            Bitmap[] rgb = null;
            Bitmap[] cmy = null;

            Task[] tasks = new Task[2];

            tasks[0] = Task.Run(() =>
            {
                rgb = BitmapUtils.SeparateRGB(orig);
            });

            tasks[1] = Task.Run(() =>
            {
                cmy = BitmapUtils.SeparateCMY(orig2);
            });

            Task.WaitAll(tasks);

            createView("Red", rgb[0]);
            createView("Blue", rgb[1]);
            createView("Green", rgb[2]);

            createView("C", cmy[0]);
            createView("M", cmy[1]);
            createView("Y", cmy[2]);

            createView("Original", orig);

        }

        private void btn_exe3_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Bitmap orig = ImageGetter.GetImageFromUser();

            if (orig == null)
                return;

            Bitmap result = BitmapUtils.HSLTransform(orig, (hsl) =>
            {
                hsl.L += hsl.L * 0.1d;
                return hsl.ToColor();
            });

            createView("Original", orig);
            createView("HLS", result);
        }
    }
}
