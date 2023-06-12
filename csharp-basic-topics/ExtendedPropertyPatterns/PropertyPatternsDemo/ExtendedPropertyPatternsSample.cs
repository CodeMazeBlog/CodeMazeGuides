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
            var bigMoneyOrder = new Order(new Payment(new Price("USD", 9900000)), new Customer("HSBC", "Banking"));
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(bigMoneyOrder));

            var vipPersonOrder = new Order(new Payment(new Price("USD", 5)), new Customer("Warren Buffalo", "VIP"));
            Assert.AreEqual("ImportantOrderProcessor", OrderProcessorFactory.Get(vipPersonOrder));

            //now let's make a banking order in JPY
            var japaneseOrder = new Order(new Payment(new Price("JPY", 33333333)), new Customer("Bank Of Japan", "Banking"));
            Assert.AreEqual("JapaneseBankingProcessor", OrderProcessorFactory.Get(japaneseOrder));

            //and finally match the criteria with highest 'priority'
            var cryptoOrder = new Order(new Payment(new Price("BTC", 100)), new Customer("Bank Of Japan", "Banking"));
            Assert.AreEqual("CryptoOrderProcessor", OrderProcessorFactory.Get(cryptoOrder));
        }

        [Test]
        public void OrderValidator_UnallowedOrderType_ThrowsAnError()
        {
            var order = new Order(new Payment(new Price("BTC", 1000)), new Customer("Jim Beam", "Retail"));
            Assert.Throws<InvalidOperationException>(() => OrderValidator.Validate(order));
        }

        [Test]
        public void OrderValidator_AllowedOrderType_DoesNotThrow()
        {
            var order = new Order(new Payment(new Price("BTC", 1000)), new Customer("Jack Black", "Enterprise"));
            Assert.DoesNotThrow(() => OrderValidator.Validate(order));
        }
    }
}