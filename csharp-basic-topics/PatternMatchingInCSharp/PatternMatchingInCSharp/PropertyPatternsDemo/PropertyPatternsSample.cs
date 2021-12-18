using NUnit.Framework;
using System;

namespace PropertyPatternsDemo
{
    public class PropertyPatternsSample
    {
        //let's declare a data model that is small, but contains enough property nesting to show our point
        record Order(Payment Payment, Customer Customer);
        record Payment(Price Price, DateTime? PaymentDate = null);
        record Price(string Currency, decimal Amount);
        record Customer(string Name, string Group);


        //let's pretend this class is a Factory that creates an *instance of an order processor* based on some data in the order
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

        [Test]
        public void OrderProcessorFactory_ProperProcessorReturnedDependingOnOrder()
        {
            //first let's test a regular order
            var standardOrder = new Order(new Payment(new Price("USD", 1000)), new Customer("HSBC", "Banking"));
            Assert.AreEqual("DefaultOrderProcessor", OrderProcessorFactory.Get(standardOrder));

            //now let's make it match a bit more specific criteria
            var highPriorityOrder = standardOrder with { Payment = new Payment(new Price("USD", 9900000)) };
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder));
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder with { Payment = new Payment(new Price("USD", 5)), Customer = new Customer("John Doe", "VIP")}));

            //now let's make a banking order in JPY
            var japaneseOrder = new Order(new Payment(new Price("JPY", 33333333)), new Customer("Bank Of Japan", "Banking"));
            Assert.AreEqual("JapaneseBankingProcessor", OrderProcessorFactory.Get(japaneseOrder));

            //and finally match the criteria with highest 'priority'
            Assert.AreEqual("CryptoOrderProcessor", OrderProcessorFactory.Get(japaneseOrder with { Payment = new Payment( new Price("BTC", 100)) }));
        }

        //let's pretend this class enforces some business rules to ensure Orders are valid.
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

        [Test]
        public void OrderValidator_ThrowsAnErrorWhenNeeded()
        {
            //first let's test an unallowed order type
            var order = new Order(new Payment(new Price("BTC", 1000)), new Customer("Jim Beam", "Retail"));
            Assert.Throws<InvalidOperationException>(() => OrderValidator.Validate(order));

            //now let's modify the order so that it is allowed
            Assert.DoesNotThrow(() => OrderValidator.Validate(order with { Customer = new Customer("Jack Black", "Enterprise")}));
        }
    }
}