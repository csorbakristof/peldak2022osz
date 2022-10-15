using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class TestCRDP01
    {
        [Fact]
        public void SingleAmountDiscountWithOneAmount()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            s.RegisterAmountDiscount('A', 1, 0.9);
            var price = s.GetPrice("A");
            Assert.Equal(9, price);
        }

        [Fact]
        public void SingleAmountDiscount()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            s.RegisterProduct('B', 100);
            s.RegisterAmountDiscount('A', 5, 0.9);
            var price = s.GetPrice("AAAAAAB");
            Assert.Equal(6 * 10 * 0.9 + 100, price);
        }

        [Fact]
        public void MultipleAmountDiscounts()
        {
            Core.Shop s = new();
            s.RegisterProduct('A', 10);
            s.RegisterProduct('B', 100);
            s.RegisterAmountDiscount('A', 2, 0.9);
            s.RegisterAmountDiscount('B', 2, 0.8);
            var price = s.GetPrice("AAABB");
            Assert.Equal(3 * 10 * 0.9 + 2 * 100 * 0.8, price);
        }
    }
}
