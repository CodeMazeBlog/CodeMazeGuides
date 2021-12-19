using NUnit.Framework;
using System;

namespace PropertyPatternsTest
{
    [TestFixture]
    public class ExtendedPropertyPatternsTest
    {
        [Test]
        public void OrderProcessorFactory_ProperProcessorReturnedDependingOnOrder()
        {
            //first let's test a regular order
            var standardOrder = new Order(new Payment(new Price("USD", 1000)), new Customer("HSBC", "Banking"));
            Assert.AreEqual("DefaultOrderProcessor", OrderProcessorFactory.Get(standardOrder));

            //now let's make it match a bit more specific criteria
            var highPriorityOrder = standardOrder with { Payment = new Payment(new Price("USD", 9900000)) };
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder));
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(highPriorityOrder with { Payment = new Payment(new Price("USD", 5)), Customer = new Customer("John Doe", "VIP") }));

            //now let's make a banking order in JPY
            var japaneseOrder = new Order(new Payment(new Price("JPY", 33333333)), new Customer("Bank Of Japan", "Banking"));
            Assert.AreEqual("JapaneseBankingProcessor", OrderProcessorFactory.Get(japaneseOrder));

            //and finally match the criteria with highest 'priority'
            Assert.AreEqual("CryptoOrderProcessor", OrderProcessorFactory.Get(japaneseOrder with { Payment = new Payment(new Price("BTC", 100)) }));
        }

        [Test]
        public void OrderValidator_ThrowsAnErrorWhenNeeded()
        {
            //first let's test an unallowed order type
            var order = new Order(new Payment(new Price("BTC", 1000)), new Customer("Jim Beam", "Retail"));
            Assert.Throws<InvalidOperationException>(() => OrderValidator.Validate(order));

            //now let's modify the order so that it is allowed
            Assert.DoesNotThrow(() => OrderValidator.Validate(order with { Customer = new Customer("Jack Black", "Enterprise") }));
        }
    }
}