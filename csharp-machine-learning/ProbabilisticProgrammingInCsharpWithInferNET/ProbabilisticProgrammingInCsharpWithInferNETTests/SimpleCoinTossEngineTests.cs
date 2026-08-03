using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;
using System.Linq;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests;

[TestClass]
public class SimpleCoinTossEngineTests
{
    [TestMethod]
    [DataRow(1)]
    [DataRow(10)]
    [DataRow(50)]
    [DataRow(100)]
    [DataRow(200)]
    public void WhenCoinTossCountHeadsAndCalculateAverage_ThenSuccess(int experimentsCount)
    {
        var coinTossEngine = new CoinTossEngine();
        var headCounts = coinTossEngine.IsCoinFairExperiments(experimentsCount);
        var average = headCounts.Average();

        Console.WriteLine($"Experiment count: {experimentsCount}, head count average: {average}");

        Assert.AreNotEqual(average, 500000, 1e-3);
    }

    [TestMethod]
    public void WhenBothHeadsTrue_ThenSuccess()
    {
        var coinTossEngine = new CoinTossEngine();
        coinTossEngine.TossTheCoins();

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.AreEqual(25.0, coinTossEngine.BothCoinsPercentage, 1.0);
    }

    [TestMethod]
    public void WhenBothHeadsNotTrue_ThenSuccess()
    {
        var coinTossEngine = new CoinTossEngine();
        coinTossEngine.TossTheCoins(condition: m => !m.BothHeads);

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.AreEqual(33.0, coinTossEngine.FirstCoinPercentage, 1.0);
    }
}