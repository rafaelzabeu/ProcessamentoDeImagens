using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.ImageProcessing
{
    public class BlobFinder
    {
        readonly int WHITE = Color.White.ToArgb();
        readonly int BLACK = Color.Black.ToArgb();

        readonly int BLOB_THRESHOLD = 20;

        private List<Blob> m_blobs;

        private int[,] m_visited;

        private int m_current;
        private List<int> m_validIndexs;

        public int Find(Bitmap bi)
        {
            Bitmap bitmap = BitmapUtils.Limiarize(bi, 225);
            BitmapData data = bitmap.LockBits(new Rectangle(
                0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            m_blobs = new List<Blob>();
            m_current = 0;
            m_validIndexs = new List<int>();
            m_visited = new int[bi.Width, bi.Height];

            unsafe
            {
                int pixelSize = 3;

                byte* row = (byte*)data.Scan0;

                int width = bitmap.Width;
                int height = bitmap.Height;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //find our pixel in the memory
                        int ptrIndex = (x * pixelSize) + (y * data.Stride);

                        //get its colors, stored in memory as BGR
                        int r = (int)row[ptrIndex + 2];
                        int g = (int)row[ptrIndex + 1];
                        int b = (int)row[ptrIndex];

                        Color c = Color.FromArgb(r, g, b);

                        if (c.Compare(BLACK))
                        {
                            int i = CheckNeighbours(x, y);
                            m_visited[x, y] = i;
                            if (m_blobs.Count <= i - 1)
                            {
                                m_blobs.Add(new Blob());
                            }
                            m_blobs[i - 1].Points.Add(new Point(x, y));

                        }
                    }
                }

            }

            return m_validIndexs.Count;

        }

        private List<Blob> filterBlobs(int minSize, List<Blob> blobs)
        {
            List<Blob> newBlob = new List<Blob>();
            foreach (var item in blobs)
            {
                if (item.Points.Count > minSize)
                    newBlob.Add(item);
            }

            return newBlob;
        }

        private int CheckNeighbours(int x, int y)
        {

            int cima = y - 1 > -1 ? y - 1 : -1;
            int baixo = y + 1 < m_visited.GetLength(1) ? y + 1 : -1;
            int esquerda = x - 1 > -1 ? x - 1 : -1;
            int direita = x + 1 < m_visited.GetLength(0) ? x + 1 : -1;

            int indexToReturn = int.MaxValue;

            if (cima > -1 && m_visited[x, cima] > 0)
            {
                if (indexToReturn > m_visited[x, cima])
                {
                    indexToReturn = m_visited[x, cima];
                }
                else if(indexToReturn < m_visited[x, cima])
                {
                    m_validIndexs.Remove(m_visited[x, cima]);
                    m_visited[x, cima] = indexToReturn;
                }

            }
            if (esquerda > -1 && m_visited[esquerda, y] > 0)
            {
                if (indexToReturn > m_visited[esquerda, y])
                {
                    indexToReturn = m_visited[esquerda, y];
                }
                else if (indexToReturn < m_visited[esquerda, y])
                {
                    m_validIndexs.Remove(m_visited[esquerda, y]);
                    m_visited[esquerda, y] = indexToReturn;
                }

            }
            if (baixo > -1 && m_visited[x, baixo] > 0)
            {
                if (indexToReturn > m_visited[x, baixo])
                {
                    indexToReturn = m_visited[x, baixo];
                }
                else if (indexToReturn < m_visited[x, baixo])
                {
                    m_validIndexs.Remove(m_visited[x, baixo]);
                    m_visited[x, baixo] = indexToReturn;
                }

            }
            if (direita > -1 && m_visited[direita, y] > 0)
            {
                if (indexToReturn > m_visited[direita, y])
                {
                    indexToReturn = m_visited[direita, y];
                }
                else if (indexToReturn < m_visited[direita, y])
                {
                    m_validIndexs.Remove(m_visited[direita, y]);
                    m_visited[direita, y] = indexToReturn;
                }

            }
            
            if(indexToReturn == int.MaxValue)
            {
                indexToReturn = ++m_current;
                m_validIndexs.Add(indexToReturn);
            }
            return indexToReturn;
        }

    }
}
