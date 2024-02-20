using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProbabilisticProgrammingInCsharpWithInferNET;
using System;

namespace ProbabilisticProgrammingInCsharpWithInferNETTests;

[TestClass]
public class CoinTossInferNetEngineTests
{

    [TestMethod]
    public void WhenBothHeadsTrue_ThenSuccess()
    {
        var coinTossInferNetEngine = new CoinTossInferNetEngine();
        coinTossInferNetEngine.TossTheCoins();

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossInferNetEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossInferNetEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossInferNetEngine.BothCoinsPercentage}%");

        Assert.AreEqual(coinTossInferNetEngine.BothCoinsPercentage, 25.0, 1e-3);
    }

    [TestMethod]
    public void WhenBothHeadsNotTrue_ThenSuccess()
    {
        var coinTossInferNetEngine = new CoinTossInferNetEngine();
        coinTossInferNetEngine.TossTheCoins(condition: m => m.BothHeads.ObservedValue = false);

        Console.WriteLine($"Probability First Coin Is Heads: {coinTossInferNetEngine.FirstCoinPercentage}%");
        Console.WriteLine($"Probability Second Coin Is Heads: {coinTossInferNetEngine.SecondCoinPercentage}%");
        Console.WriteLine($"Probability Both Coins Are Heads: {coinTossInferNetEngine.BothCoinsPercentage}%");

        Assert.AreEqual(coinTossInferNetEngine.FirstCoinPercentage, 33.33, 1e-3);
    }
}