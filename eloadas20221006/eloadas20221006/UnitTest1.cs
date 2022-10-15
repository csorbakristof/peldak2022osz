using Common;

namespace eloadas20221006
{
    public class UnitTest1
    {
        public IEnumerable<int> GetNumbers()
        {
            for (int i = 1; i <= 5; i++)
                yield return i;
        }

        [Fact]
        public void Test1()
        {
            var source = GetNumbers();

            int count = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext()) count++;
            Assert.Equal(5, count);

            //enumerator.MoveNext();
            //var szam = enumerator.Current;
            //enumerator.MoveNext();
            //var szam2 = enumerator.Current;

            Assert.Equal(5, source.Count());
            Assert.Equal(1, source.Min());
        }

        private PrimeGenerator generator = new PrimeGenerator();

        [Fact]
        public void TestTruePrimes()
        {
            var primes = generator.GetNumbers(10).ToArray(); // ToArray nélkül 3x fut végig...
            Assert.Contains(3, primes);
            Assert.Contains(5, primes);
            Assert.Contains(7, primes);
        }

        [Fact]
        public void TestFalsePrimes()
        {
            var primes = generator.GetNumbers(10).ToArray(); // ToArray nélkül 3x fut végig...
            Assert.DoesNotContain(6, primes);
            Assert.DoesNotContain(4, primes);
        }
    }
}
