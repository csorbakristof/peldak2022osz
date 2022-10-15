using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    internal abstract class TurkmiteBase
    {
        protected int x = 100;
        protected int y = 100;
        protected int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        protected Mat.Indexer<Vec3b> indexer;

        public abstract int OptimalStepNumber();

        public TurkmiteBase(Mat.Indexer<Vec3b> indexer)
        {
            this.indexer = indexer;
        }

        public void Step()
        {
            Vec3b currentColor = indexer[y, x];
            
            ApplyRules(currentColor);

            direction = (direction + 4) % 4;
            Move();
            KeepBoundaries();
        }

        protected abstract void ApplyRules(Vec3b currentColor);

        #region Motion
        private readonly int[] deltaX = new int[] { 0, 1, 0, -1 };
        private readonly int[] deltaY = new int[] { -1, 0, 1, 0 };

        private void Move()
        {
            x += deltaX[direction];
            y += deltaY[direction];
        }

        private void KeepBoundaries()
        {
            x = Math.Max(0, Math.Min(x, 199));
            y = Math.Max(0, Math.Min(y, 199));
        }
        #endregion
    }
}
