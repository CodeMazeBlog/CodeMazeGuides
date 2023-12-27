using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;
using System.Linq;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests;

[TestClass]
public class SimpleCoinTossEngineTests
{
    CoinTossEngine coinTossEngine = new CoinTossEngine();


    [TestMethod]
    public void WhenCoinTossCountHeadsAndCalculateAverage_ThanSuccess()
    {
        var experimentsCounts = new int[] { 1, /*10, 50, 100, 200*/ };
        foreach (var count in experimentsCounts)
        {
            var headCounts = coinTossEngine.IsCoinFairExperiments(count);
            var average = headCounts.Average();

            Console.WriteLine($"Experiment count: {count}, head count average: {average}");

            Assert.IsFalse(average == 500000);
        }
    }

    [TestMethod]
    public void WhenBothHeadsTrue_ThanSuccess()
    {
        coinTossEngine.TossTheCoins();

        Console.WriteLine($"Probability First Coin Is Head: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Head: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.IsTrue(Math.Round(coinTossEngine.BothCoinsPercentage, 0) == 25.0);
    }

    [TestMethod]
    public void WhenBothHeadsNotTrue_ThanSuccess()
    {
        coinTossEngine.TossTheCoins(condition: m => !m.BothHeads);

        Console.WriteLine($"Probability First Coin Is Head: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Head: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.IsTrue(Math.Round(coinTossEngine.FirstCoinPercentage, 0) == 33.0);
    }
}