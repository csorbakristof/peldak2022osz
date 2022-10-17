using OpenCvSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    internal class TriColorTurkmite : TurkmiteBase
    {
        public override int OptimalStepNumber()
        {
            return 20000;
        }

        public readonly Vec3b Black = new Vec3b(0, 0, 0);
        public readonly Vec3b Yellow = new Vec3b(0, 255, 255);
        public readonly Vec3b Red = new Vec3b(0, 0, 255);

        public TriColorTurkmite(Mat.Indexer<Vec3b> indexer) : base(indexer)
        {
        }

        protected override void ApplyRules(Vec3b currentColor)
        {
            if (currentColor == Black)
            {
                indexer[y, x] = Red;
                direction++;
            }
            else if (currentColor == Red)
            {
                indexer[y, x] = Yellow;
                direction--;
            }
            else
            {
                indexer[y, x] = Black;
                direction--;
            }
        }
    }
}
