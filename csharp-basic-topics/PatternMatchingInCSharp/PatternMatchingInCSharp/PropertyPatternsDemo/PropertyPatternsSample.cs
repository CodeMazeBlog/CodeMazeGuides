using NUnit.Framework;
using System;

namespace PropertyPatternsDemo
{
    public class PropertyPatternsSample
    {
        //let's declare a data model that is small, but contains enough property nesting to show our point
        record Order(FinancialData FinancialData, Customer Customer);
        record FinancialData(Price Price, DateTime? PaymentDate = null);
        record Price(string Currency, decimal Amount);
        record Customer(string Name, string Group);


        //let's pretend this class is a Factory that creates an *instance of an order processor* based on some data in the order
        static class OrderProcessorFactory
        {
            public static string Get(Order order) => order switch
            {
                { FinancialData.Price.Currency: "BTC" } => "CryptoOrderProcessor",
                { Customer.Group: "Banking", FinancialData.Price.Currency: "JPY" } => "JapaneseBankingProcessor",
                { FinancialData.Price.Amount: >= 500000 } or { Customer.Group: "VIP" } => "ImportantOrderProcessor",
              //{ FinancialData: { Price: { Amount: > 5000000} } } or { Customer: { Group: "VIP" } } => "ImportantOrderProcessor", <- this is the equivalent expression without using the C# 10 feature
                _ => "DefaultOrderProcessor"
            };
        }

        [Test]
        public void OrderProcessorFactory_ProperProcessorReturnedDependingOnOrder()
        {
            //first let's test a regular order
            var standardOrder = new Order(new FinancialData(new Price("USD", 1000)), new Customer("HSBC", "Banking"));
            Assert.AreEqual("DefaultOrderProcessor", OrderProcessorFactory.Get(standardOrder));

            //now let's make it match a bit more specific criteria
            var highPriorityOrder = standardOrder with { FinancialData = new FinancialData(new Price("USD", 9900000)) };
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder));
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder with {FinancialData = new FinancialData(new Price("USD", 5)), Customer = new Customer("John Doe", "VIP")}));

            //now let's make a banking order in JPY
            var japaneseOrder = new Order(new FinancialData(new Price("JPY", 33333333)), new Customer("Bank Of Japan", "Banking"));
            Assert.AreEqual("JapaneseBankingProcessor", OrderProcessorFactory.Get(japaneseOrder));

            //and finally match the criteria with highest 'priority'
            Assert.AreEqual("CryptoOrderProcessor", OrderProcessorFactory.Get(japaneseOrder with { FinancialData = new FinancialData( new Price("BTC", 100)) }));
        }


        




    }
}