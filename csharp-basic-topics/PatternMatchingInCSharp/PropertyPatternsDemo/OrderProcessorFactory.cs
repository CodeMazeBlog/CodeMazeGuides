namespace PropertyPatternsTest
{
    /// <summary>
    /// let's pretend this class is a Factory that creates an *instance of an order processor* based on some data in the order
    /// </summary>
    static class OrderProcessorFactory
    {
        public static string Get(Order order) => order switch
        {
            { Payment.Price.Currency: "BTC" } => "CryptoOrderProcessor",
            { Customer.Group: "Banking", Payment.Price.Currency: "JPY" } => "JapaneseBankingProcessor",
            { Payment.Price.Amount: >= 500000 } or { Customer.Group: "VIP" } => "ImportantOrderProcessor",
            //{ Payment: { Price: { Amount: > 5000000} } } or { Customer: { Group: "VIP" } } => "ImportantOrderProcessor",// <- this is the equivalent expression without using the C# 10 feature
            _ => "DefaultOrderProcessor"
        };
    }

}