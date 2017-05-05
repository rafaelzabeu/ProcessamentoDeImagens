using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lista1
{
    public partial class BitmapHeaderInfoScreen : Form
    {
        public BitmapHeaderInfoScreen(IDictionary<string,string> infos)
        {
            InitializeComponent();

            foreach (var item in infos)
            {
                richTextBox1.AppendText(string.Format("\n {0}:{1}", item.Key, item.Value));
            }

        }
    }
}
