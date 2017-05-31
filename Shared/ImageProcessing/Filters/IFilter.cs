using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing.Filters
{
    public interface IFilter
    {
        int MaskSize { get; }
        Color GetColor(Color[,] colors);
    }
}
