namespace ActionFuncInCSharp
{
    public static class ProductFunctions
    {
        public static Func<Product, bool> PriceIsLessThan(double price)
        {
            return p => p.Price < price;
        }

        public static Func<Product, bool> PriceIsLessThan(double price, bool logOnPredicated = false)
        {
            return p =>
            {
                var predicated = p.Price < price;

                if (logOnPredicated && predicated)
                {
                    LoggingActions.LogObjectsToConsole(p);
                }

                return predicated;
            };
        }
    }
}
