using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    internal class Turkmite : TurkmiteBase
    {
        public Turkmite(Mat.Indexer<Vec3b> indexer) : base(indexer)
        {
        }

        private readonly Vec3b black = new Vec3b(0, 0, 0);
        private readonly Vec3b white = new Vec3b(255, 255, 255);

        public override int OptimalStepNumber() => 13000;

        protected override void ApplyRules(Vec3b currentColor)
        {
            if (currentColor == black)
            {
                indexer[y, x] = white;
                direction++;
            }
            else
            {
                indexer[y, x] = black;
                direction--;
            }
        }
    }
}
