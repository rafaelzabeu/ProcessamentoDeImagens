using Lista1;
using Shared;
using Shared.ColorTypes;
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
    public partial class Lista1 : Form
    {

        public Lista1()
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
            Bitmap orig = ImageGetter.GetImageFromUser();

            if (orig == null)
                return;

            Bitmap[] result = BitmapUtils.SeparateRGB(orig);

            CreateView("Red", result[0]);
            CreateView("Blue", result[1]);
            CreateView("Green", result[2]);
            CreateView("Original", orig);
        }

        private void btn_exe2_Click(object sender, EventArgs e)
        {
            closeOtherExercises();

            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;

            Bitmap[] rgb = BitmapUtils.SeparateRGB(orig);
            Bitmap[] cmy = BitmapUtils.SeparateCMY(orig);

        

            CreateView("Red", rgb[0]);
            CreateView("Blue", rgb[1]);
            CreateView("Green", rgb[2]);

            CreateView("C", cmy[0]);
            CreateView("M", cmy[1]);
            CreateView("Y", cmy[2]);

            CreateView("Original", orig);

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

            CreateView("Original", orig);
            CreateView("HLS", result);
        }

        private void btn_exe4_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;

            Bitmap other = BitmapUtils.ChangePixelSize(orig, 12);

            CreateView("Orig", orig);
            CreateView("12 bits", other);
        }

        private void btn_exc5_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            OpenFileDialog dig = new OpenFileDialog();
            dig.Title = "Select an image";
            if(dig.ShowDialog() == DialogResult.OK)
            {
                byte[] bytes = System.IO.File.ReadAllBytes(dig.FileName);

                Dictionary<string, string> info = new Dictionary<string, string>();

                info.Add("HeaderField", Encoding.ASCII.GetString(bytes.Take(2).ToArray()));
                info.Add("Size", BitConverter.ToInt32(bytes.Skip(2).Take(4).ToArray(), 0).ToString());
                info.Add("Reserved1", Encoding.ASCII.GetString(bytes.Skip(6).Take(2).ToArray()));
                info.Add("Reserved2", Encoding.ASCII.GetString(bytes.Skip(8).Take(2).ToArray()));
                info.Add("Offset", Encoding.ASCII.GetString(bytes.Skip(10).Take(4).ToArray()));
                info.Add("Width", Encoding.ASCII.GetString(bytes.Skip(18).Take(4).ToArray()));
                info.Add("Height", Encoding.ASCII.GetString(bytes.Skip(22).Take(4).ToArray()));
                info.Add("Bit per pixel", Encoding.ASCII.GetString(bytes.Skip(28).Take(2).ToArray()));
                info.Add("Compression", Encoding.ASCII.GetString(bytes.Skip(30).Take(4).ToArray()));

                Form f = new BitmapHeaderInfoScreen(info);
                f.Show();

                m_openForms.Add(f);
            }
        }

        private void btn_exe6_Click(object sender, EventArgs e)
        {
            closeOtherExercises();
            Bitmap orig = ImageGetter.GetImageFromUser();
            if (orig == null)
                return;

            Bitmap yuv422 = BitmapUtils.ConvertToYUV422(orig);
            Bitmap yuv420 = BitmapUtils.ConvertToYUV420(orig);

            CreateView("Orig", orig);
            CreateView("YUV422", yuv422);
            CreateView("YUV420", yuv420);

        }
    }
}
