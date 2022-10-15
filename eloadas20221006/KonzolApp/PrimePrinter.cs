using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KonzolApp
{
    internal class PrimePrinter
    {
        public static void Main()
        {
            IGenerator generator = new EvenGenerator();
            //IGenerator generator = new PrimeGenerator();
            foreach (var prim in generator.GetNumbers(10))
                Console.WriteLine(prim);
        }

    }
}
