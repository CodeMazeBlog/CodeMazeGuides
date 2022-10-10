using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncInCsharp.Tests
{
    [TestClass]
    public class ActionUnitTests
    {
        [TestMethod]
        public void Given10Apples_WhenBuy1Apple_Then9Apples()
        {
            var service = new ActionMarketService(10);

            service.BuyApple.Invoke();

            Assert.AreEqual(9, ActionMarketService.Apples);
        }

        [TestMethod]
        public void Given0Apples_WhenBuy1Apple_Then0Apples()
        {
            var service = new ActionMarketService(0);

            service.BuyApple();

            Assert.AreEqual(0, ActionMarketService.Apples);
        }

        [TestMethod]
        public void Given5Apples_WhenBuy4Apple_Then1Apples()
        {
            var service = new ActionMarketService(5);

            service.BuyApples.Invoke(4);

            Assert.AreEqual(1, ActionMarketService.Apples);
        }

        [TestMethod]
        public void Given5Apples_WhenBuy5Apple_Then0Apples()
        {
            var service = new ActionMarketService(5);

            service.BuyApples(5);

            Assert.AreEqual(0, ActionMarketService.Apples);
        }
    }
}
