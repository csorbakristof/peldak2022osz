using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class PrimeGenerator : IGenerator
    {

        public IEnumerable<int> GetNumbers(int limit)
        {
            for (int i = 2; i <= limit; i++)
                if (IsPrime(i))
                    yield return i;
        }

        private bool IsPrime(int number)
        {
            for (int i = 2; i <= number / 2; i++)
                if (number % i == 0)
                    return false;
            return true;
        }
    }
}
