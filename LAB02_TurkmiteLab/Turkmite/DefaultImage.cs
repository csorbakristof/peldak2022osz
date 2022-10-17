using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    public class DefaultImage : IImage
    {
        Mat image;
        Mat.Indexer<Vec3b> indexer;

        public DefaultImage()
        {
            image = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            indexer = image.GetGenericIndexer<Vec3b>();
        }

        public Vec3b GetColor(int x, int y)
        {
            return indexer[y, x];
        }

        public void SetColor(int x, int y, Vec3b color)
        {
            indexer[y, x] = color;
        }

        internal void Show()
        {
            Cv2.ImShow("TurkMite", image);
        }
    }
}
