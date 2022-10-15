namespace Core
{
    public class AmountDiscount
    {
        public AmountDiscount(char productName, int minCount, double multiplier, Shop shop)
        {
            ProductName = productName;
            MinCount = minCount;
            Multiplier = multiplier;
            Shop = shop;
        }

        public char ProductName { get; set; }
        public int MinCount { get; set; }
        public double Multiplier { get; set; }
        public Shop Shop { get; }

        public int GetPriceReduction(string basket)
        {
            return basket.Count(p => p == ProductName) >= MinCount
                ? basket.Count(p => p == ProductName) * (int)Math.Round(
                    Shop.Prices[ProductName] * (1.0 - Multiplier))
                : 0;
        }
    }
}
