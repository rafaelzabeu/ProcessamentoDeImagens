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

        private bool[,] m_visited;

        public List<Blob> GetNumOfBlobs(Bitmap image)
        {
            m_visited = new bool[image.Width, image.Height];
            m_blobs = new List<Blob>();

            Bitmap gray = BitmapUtils.Limiarize(image, 220);

            BitmapData data = gray.LockBits(new Rectangle(
                0, 0, gray.Width, gray.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                int pixelSize = 3;

                byte* row = (byte*)data.Scan0;

                int width = gray.Width;
                int height = gray.Height;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        if (!m_visited[x, y])
                        {
                            int ptrIndex = (x * pixelSize) + (y * data.Stride);
                            int r = row[ptrIndex + 2];
                            int g = row[ptrIndex + 1];
                            int b = row[ptrIndex];

                            Color c = Color.FromArgb(r, g, b);
                            if (c.Compare(WHITE))
                            {
                                Blob blob = CheckBlob(x, y, row, data.Stride, width, height);
                                if (blob != null)
                                    m_blobs.Add(blob);                                
                            }
                        }
                    }
                }

            }

            gray.UnlockBits(data);

            GC.Collect();

            return m_blobs;
        }

        private unsafe Blob CheckBlob(int x, int y, byte* row, int stride, int width, int height)
        {
            Blob blob = new Blob();
            Queue<Point> pointsToSee = new Queue<Point>();

            pointsToSee.Enqueue(new Point(x, y));
            m_visited[x, y] = true;

            while(pointsToSee.Count > 0)
            {
                Point p = pointsToSee.Dequeue();

                if (x - 1 > -1 && !m_visited[x - 1, y])
                    CheckPixel(x - 1, y, row, stride, pointsToSee);

                if (x + 1 < width && !m_visited[x + 1, y])
                    CheckPixel(x + 1, y, row, stride, pointsToSee);

                if (y - 1 > -1 && !m_visited[x, y - 1])
                    CheckPixel(x, y - 1, row, stride, pointsToSee);

                if (y + 1 < height && !m_visited[x, y + 1])
                    CheckPixel(x, y + 1, row, stride, pointsToSee);

            }

            if (blob.Points.Count >= BLOB_THRESHOLD)
                return blob;
            else
                return null;
        }

        private unsafe void CheckPixel(int x, int y, byte* row, int stride, Queue<Point> pointsToSee)
        {
            int prtIndex = (x * 3) + (y * stride);
            int r = row[prtIndex + 2];
            int g = row[prtIndex + 1];
            int b = row[prtIndex];

            Color c = Color.FromArgb(r, g, b);
            if(c.Compare(BLACK))
            {
                m_visited[x, y] = true;
                pointsToSee.Enqueue(new Point(x, y));
            }

        }

    }

}
