using OpenCvSharp;

namespace LAB02_TurkmiteLab
{
    class Program
    {
        static void Main()
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var indexer = img.GetGenericIndexer<Vec3b>();
            var t = new TriColorTurkmite(indexer);
 
            for(int i=0; i<t.OptimalStepNumber(); i++)
            {
                t.Step();
            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}
