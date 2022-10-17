using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    public class Turkmite : TurkmiteBase
    {
        public Turkmite(Mat.Indexer<Vec3b> indexer) : base(indexer)
        {
        }

        public readonly Vec3b Black = new Vec3b(0, 0, 0);
        public readonly Vec3b White = new Vec3b(255, 255, 255);

        public override int OptimalStepNumber() => 13000;

        protected override void ApplyRules(Vec3b currentColor)
        {
            if (currentColor == Black)
            {
                indexer[y, x] = White;
                direction++;
            }
            else
            {
                indexer[y, x] = Black;
                direction--;
            }
        }
    }
}
