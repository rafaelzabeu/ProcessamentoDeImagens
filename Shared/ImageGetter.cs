using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shared
{
    public static class ImageGetter
    {
        /// <summary>
        /// Asks the user to choose an image.
        /// If the user chooses nothing or a file that cannot be converted to Bitmap
        /// the function returns null.
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetImageFromUser()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select an image";

            Bitmap bit = null;

            try
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    bit = new Bitmap(dialog.OpenFile());

                }
            }
            catch(Exception e)
            {
                
            }
            return bit;
        }
    }
}
