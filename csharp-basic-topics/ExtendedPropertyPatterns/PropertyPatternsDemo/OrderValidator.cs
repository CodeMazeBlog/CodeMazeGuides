using System;

namespace PropertyPatternsTest
{
    static class OrderValidator
    {
        public static void Validate(Order order)
        {
            //current syntax version (different rules would be validated further below)
            if (order is { Payment.Price.Currency: "BTC" } and { Customer.Group: "Retail" })
            {
                throw new InvalidOperationException("Crypto transactions not allowed for retail customers");
            }

            //as above, but without extended property patters (C# 8.0)
            if (order is { Payment: { Price: { Currency: "BTC" } } } and { Customer: { Group: "Retail" } })
            {
                throw new InvalidOperationException("Crypto transactions not allowed for retail customers");
            }

            //the same without pattern matching
            if (order.Payment.Price.Currency == "BTC" && order.Customer.Group == "Retail")
            {
                throw new InvalidOperationException("Crypto transactions not allowed for retail customers");
            }
        }
    }
}