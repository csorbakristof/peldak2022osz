using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EvenGenerator : IGenerator
    {
        public IEnumerable<int> GetNumbers(int limit)
        {
            for (int i = 1; i < limit; i++)
                if (i % 2 == 0)
                    yield return i;
        }
    }
}
