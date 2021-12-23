namespace PropertyPatternsTest
{
    static class OrderProcessorFactory
    {
        public static string Get(Order order) => order switch
        {
            { Payment.Price.Currency: "BTC" } => "CryptoOrderProcessor",
            { Customer.Group: "Banking", Payment.Price.Currency: "JPY" } => "JapaneseBankingProcessor",
            { Payment.Price.Amount: >= 500000 } or { Customer.Group: "VIP" } => "ImportantOrderProcessor",
            _ => "DefaultOrderProcessor"
        };

        public static string Get_PreCSharp10Syntax(Order order) => order switch
        {
            { Payment: {  Price: { Currency: "BTC" } } } => "CryptoOrderProcessor",
            { Customer: { Group: "Banking" }, Payment: { Price: { Currency: "JPY" } } } => "JapaneseBankingProcessor",
            { Payment: { Price: { Amount: > 5000000} } } or { Customer: { Group: "VIP" } } => "ImportantOrderProcessor",
            _ => "DefaultOrderProcessor"
        };
    }

}