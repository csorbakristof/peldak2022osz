using OpenCvSharp;

namespace LAB02_TurkmiteLab
{
    class Program
    {
        static void Main()
        {
            var img = new DefaultImage();
            var t = CreateTurkmite(3,img);
 
            for(int i=0; i<t.OptimalStepNumber(); i++)
            {
                t.Step();
            }
            img.Show();
            Cv2.WaitKey();
        }

        private static TurkmiteBase CreateTurkmite(int numberOfColors, IImage img)
        {
            return numberOfColors == 2
                ? new Turkmite(img)
                : new TriColorTurkmite(img);
        }
    }
}
