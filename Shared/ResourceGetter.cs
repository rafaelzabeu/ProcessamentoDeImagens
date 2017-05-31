using Shared.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    internal class ResourceGetter
    {
        public static void GetSobel(int size, out double[,] xMatrix, out double[,] yMatrix)
        {
            string raw = GetSobelString(size);

            xMatrix = new double[size, size];
            yMatrix = new double[size, size];
            int halfSize = size / 2;

            string[] slipt = raw.Trim().Split('\n');

            int x = 0;

            for (int w = 0; w < slipt.Length; w++)
            {
                if (!string.IsNullOrWhiteSpace(slipt[w]))
                {
                    string[] line = slipt[w].Split(',');
                    for (int y = 0; y < size; y++)
                    {
                        if (w < slipt.Length / 2)
                            xMatrix[x % size, y] = Convert.ToDouble(line[y]);
                        else
                            yMatrix[x % size, y] = Convert.ToDouble(line[y]);
                    }
                    x++;
                }

            }
        }

        private static string GetSobelString(int size)
        {
            if (size == 3)
                return Resources.Sobel3;
            else if (size == 5)
                return Resources.Sobel5;

            throw new Exception($"Sobel table of size {size}x{size} not found.");
        }

    }
}
