using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ActionAndFuncInCsharp.Tests
{
    [TestClass]
    public class FuncUnitTests
    {
        [TestMethod]
        public void Given7WatermelonsAnd0Oranges_WhenIsInStock_ThenTrueForWatermelonsAndFalseForOranges()
        {
            var service = new FuncMarketService(7, 0, 0);

            var watermelonsInStock = service.IsInStock.Invoke(Stock.Watermelons);
            var orangesInStock = service.IsInStock(Stock.Oranges);

            Assert.IsTrue(watermelonsInStock);
            Assert.IsFalse(orangesInStock);
        }

        [TestMethod]
        public void GivenDefaultBuyItemsAnd3Apples_WhenBuy2Apples_ThenSuccessMessage()
        {
            var service = new FuncMarketService(0, 0, 3);

            var result = service.BuyItems(Stock.Apples, 2);

            Assert.AreEqual("You bought 2 Apples", result);
        }

        [TestMethod]
        public void GivenDefaultBuyItemsAnd3Apples_WhenBuy4Apples_ThenFailureMessage()
        {
            var service = new FuncMarketService(0, 0, 3);

            var result = service.BuyItems(Stock.Apples, 4);

            Assert.AreEqual("Not enough stock!", result);
        }

        [TestMethod]
        public void GivenCustomBuyItemsBuys10TimesAmount_When15ApplesAndBuy2Apples_ThenFailureMessage()
        {
            var service = new FuncMarketService(0, 0, 15, (Stock stockType, int amount) =>
            {
                var newAmount = amount * 10;

                if (FuncMarketService.Items[stockType] - newAmount >= 0)
                {
                    FuncMarketService.Items[stockType] -= newAmount;
                    return $"You bought {newAmount} {stockType}";
                }
                else
                {
                    return "We don't have enough of those!";
                }
            });

            // We expect our Func to try and buy 20 (2 * 10) apples this time
            var result = service.BuyItems(Stock.Apples, 2);

            Assert.AreEqual("We don't have enough of those!", result);
        }

        [TestMethod]
        public void GivenCustomBuyItemsBuys10TimesAmount_When100WatermelonsAndBuy5Watermelons_ThenSuccessMessage()
        {
            var service = new FuncMarketService(100, 0, 0, (Stock stockType, int amount) =>
            {
                var newAmount = amount * 10;

                if (FuncMarketService.Items[stockType] - newAmount >= 0)
                {
                    FuncMarketService.Items[stockType] -= newAmount;
                    return $"You bought {newAmount} {stockType}";
                }
                else
                {
                    return "We don't have enough of those!";
                }
            });

            // We expect our Func to buy 50 (5 * 10) watermelons this time
            var result = service.BuyItems(Stock.Watermelons, 5);

            Assert.AreEqual("You bought 50 Watermelons", result);
        }
    }
}
