namespace ActionAndFuncInCsharp
{
    public class FuncMarketService
    {
        public static Dictionary<Stock, int> Items { get; set; } = new Dictionary<Stock, int>();

        public Func<Stock, bool> IsInStock = (Stock stockType) => 
        {
            return Items != null && Items[stockType] > 0;
        };

        public Func<Stock, int, string> BuyItems;

        public FuncMarketService(int watermelons, int oranges, int apples)
            : this(watermelons, oranges, apples, DefaultBuyItems)
        {}

        public FuncMarketService(int watermelons, int oranges, int apples, Func<Stock, int, string> buyItemsFunc)
        {
            Items = new Dictionary<Stock, int>()
            {
                { Stock.Watermelons, watermelons },
                { Stock.Oranges, oranges },
                { Stock.Apples, apples }
            };
            BuyItems = buyItemsFunc;
        }

        private static string DefaultBuyItems(Stock stockType, int amount)
        {
            if (Items[stockType] - amount >= 0)
            {
                Items[stockType] -= amount;
                return $"You bought {amount} {stockType}";
            }
            else
            {
                return "Not enough stock!";
            }
        }
    }

    public enum Stock
    {
        Watermelons,
        Oranges,
        Apples
    }
}
