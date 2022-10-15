namespace Shop
{
    public class Basics
    {
        [Fact]
        public void Instantiation()
        {
            Core.Shop s = new();
        }

        [Fact]
        public void GetPriceOfNothing()
        {
            Core.Shop s = new();
            Assert.Equal(0, s.GetPrice(string.Empty));
        }

        [Fact]
        public void GetPriceOfSingleProduct()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            Assert.Equal(10, s.GetPrice("A"));
        }

        [Fact]
        public void GetPriceOfMultipleProducts()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            s.RegisterProduct('B', 10);
            s.RegisterProduct('C', 10);
            Assert.Equal(30, s.GetPrice("ABC"));
        }

        [Fact]
        public void GetPriceOfMultipleProductsWithDifferentPrices()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            s.RegisterProduct('B', 20);
            s.RegisterProduct('C', 30);
            Assert.Equal(60, s.GetPrice("ABC"));
        }
    }
}