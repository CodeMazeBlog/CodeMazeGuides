using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests
{
    [TestClass]
    public class SimpleCoinTossEngineTests
    {
        CoinTossEngine coinTossEngine = new CoinTossEngine();

        [TestMethod]
        public void WhenBothHeadsTrue_ThanSuccess()
        {
            coinTossEngine.TossTheCoins();

            Console.WriteLine($"P - First Coin True: {coinTossEngine.FirstCoinPercentage}%");
            Console.WriteLine($"P - Second Coin True: {coinTossEngine.SecondCoinPercentage}%");
            Console.WriteLine($"P - Both Coins True: {coinTossEngine.BothCoinsPercentage}%");

            Assert.IsTrue(Math.Round(coinTossEngine.BothCoinsPercentage, 0) == 25.0);
        }

        [TestMethod]
        public void WhenBothHeadsNotTrue_ThanSuccess()
        {
            coinTossEngine.TossTheCoins(condition: m => !m.BothHeads);

            Console.WriteLine($"P - First Coin Is Head: {coinTossEngine.FirstCoinPercentage}%");
            Console.WriteLine($"P - Second Coin Is Head: {coinTossEngine.SecondCoinPercentage}%");
            Console.WriteLine($"P - Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

            Assert.IsTrue(Math.Round(coinTossEngine.FirstCoinPercentage, 0) == 33.0);
        }

        [TestMethod]
        public void WhenCoinTossCountHeadsAndCalculateAverage_ThanSuccess()
        {
            var experimentsCounts = new int[] { 1, 10, 50 };
            foreach(var count in experimentsCounts)
            {
                var headCounts = coinTossEngine.IsCoinFairExperiments(500);
                var average = headCounts.Average();

                Console.WriteLine($"Experiment count: {count}, head count average: {average}");

                Assert.IsFalse(average == 500000);
            }
        }
    }
}