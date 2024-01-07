using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;
using System.Linq;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests;

[TestClass]
public class SimpleCoinTossEngineTests
{
    private bool ValidateResult(double expected,  double actual, double tolerance = 1.0)
    {
        return actual >= expected - tolerance &&
            actual <= expected + tolerance;
    }

    [TestMethod]
    public void WhenCoinTossCountHeadsAndCalculateAverage_ThenSuccess()
    {
        var coinTossEngine = new CoinTossEngine();
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
    public void WhenBothHeadsTrue_ThenSuccess()
    {
        var coinTossEngine = new CoinTossEngine();
        coinTossEngine.TossTheCoins();

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.IsTrue(ValidateResult(25.0, coinTossEngine.BothCoinsPercentage));
    }

    [TestMethod]
    public void WhenBothHeadsNotTrue_ThenSuccess()
    {
        var coinTossEngine = new CoinTossEngine();
        coinTossEngine.TossTheCoins(condition: m => !m.BothHeads);

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossEngine.BothCoinsPercentage}%");

        Assert.IsTrue(ValidateResult(33.0, coinTossEngine.FirstCoinPercentage));
    }
}