using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB02_TurkmiteLab
{
    public interface IImage
    {
        Vec3b GetColor(int x, int y);
        void SetColor(int x, int y, Vec3b color);
    }
}
