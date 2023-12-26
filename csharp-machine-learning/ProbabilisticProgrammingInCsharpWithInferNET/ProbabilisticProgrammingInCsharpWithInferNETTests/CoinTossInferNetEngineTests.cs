using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests
{
    [TestClass]
    public class CoinTossInferNetEngineTests
    {
        CoinTossInferNetEngine coinTossInferNetEngine = new CoinTossInferNetEngine();

        [TestMethod]
        public void WhenBothHeadsTrue_ThanSuccess()
        {
            coinTossInferNetEngine.TossTheCoins();

            Console.WriteLine($"Probability First Coin Is Head: {coinTossInferNetEngine.FirstCoinPercentage}%");
            Console.WriteLine($"Probability Second Coin Is Head: {coinTossInferNetEngine.SecondCoinPercentage}%");
            Console.WriteLine($"Probability Both Coins Are Heads: {coinTossInferNetEngine.BothCoinsPercentage}%");

            Assert.IsTrue(Math.Round(coinTossInferNetEngine.BothCoinsPercentage, 0) == 25.0);
        }

        [TestMethod]
        public void WhenBothHeadsNotTrue_ThanSuccess()
        {
            coinTossInferNetEngine.TossTheCoins(condition: m => m.BothHeads.ObservedValue = false);

            Console.WriteLine($"Probability First Coin Is Head: {coinTossInferNetEngine.FirstCoinPercentage}%");
            Console.WriteLine($"Probability Second Coin Is Head: {coinTossInferNetEngine.SecondCoinPercentage}%");
            Console.WriteLine($"Probability Both Coins Are Heads: {coinTossInferNetEngine.BothCoinsPercentage}%");

            Assert.IsTrue(Math.Round(coinTossInferNetEngine.FirstCoinPercentage, 0) == 33.0);
        }
    }
}