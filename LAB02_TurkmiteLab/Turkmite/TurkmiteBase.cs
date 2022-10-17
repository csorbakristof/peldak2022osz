using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    public abstract class TurkmiteBase
    {
        protected int x = 100;
        protected int y = 100;
        protected int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        protected IImage img;

        public abstract int OptimalStepNumber();

        public TurkmiteBase(IImage img)
        {
            this.img = img;
        }

        public void Step()
        {
            Vec3b currentColor = img.GetColor(x, y);
            
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
