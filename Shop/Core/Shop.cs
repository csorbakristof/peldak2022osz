using Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Shop
    {
        public int GetPrice(string basket)
        {
            var price = basket.Sum(p => Prices[p]);
            // Amount discount
            foreach (var d in amountDiscounts)
                price -= d.GetPriceReduction(basket);
            return price;
        }

        public readonly Dictionary<char, int> Prices = new Dictionary<char, int>();
        public void RegisterProduct(char productName, int price)
        {
            Prices.Add(productName, price);
        }

        private readonly List<AmountDiscount>
            amountDiscounts = new();
        public void RegisterAmountDiscount(char productName, int minCount, double multiplier)
        {
            amountDiscounts.Add(new AmountDiscount(productName, minCount, multiplier, this));
        }
    }
}
