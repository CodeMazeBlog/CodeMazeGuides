using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;

namespace ProbabilisticProgrammingInCsharpWithInferNET;

public class CoinTossInferNetEngine
{
    private readonly InferenceEngine _inferenceEngine = new();
    private static Variable<bool> IsHeads => Variable.Bernoulli(0.5);

    public Variable<bool> FirstHeads { get; private set; }
    public Variable<bool> SecondHeads { get; private set; }
    public Variable<bool> BothHeads { get; private set; }

    public double FirstCoinPercentage { get; private set; }
    public double SecondCoinPercentage { get; private set; }
    public double BothCoinsPercentage { get; private set; }

    public void TossTheCoins(Action<CoinTossInferNetEngine> condition = null)
    {
        FirstHeads = IsHeads;
        SecondHeads = IsHeads;
        BothHeads = FirstHeads & SecondHeads;

        condition?.Invoke(this);

        FirstCoinPercentage = Math.Round(100.0 * _inferenceEngine.Infer<Bernoulli>(FirstHeads).GetProbTrue(), 2);
        SecondCoinPercentage = Math.Round(100.0 * _inferenceEngine.Infer<Bernoulli>(SecondHeads).GetProbTrue(), 2);
        BothCoinsPercentage = Math.Round(100.0 * _inferenceEngine.Infer<Bernoulli>(BothHeads).GetProbTrue(), 2);
    }
}