using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;

namespace ProbabilisticProgrammingInCsharpWithInferNET;
public class CoinTossInferNetEngine
{
    private Variable<bool> IsHead => Variable.Bernoulli(0.5);
    public Variable<bool> FirstHead { get; private set; }
    public Variable<bool> SecondHead { get; private set; }
    public Variable<bool> BothHeads { get; private set; }

    public double FirstCoinPercentage { get; private set; }
    public double SecondCoinPercentage { get; private set; }
    public double BothCoinsPercentage { get; private set; }

    private InferenceEngine inferenceEngine = new InferenceEngine();

    public void TossTheCoins(Func<CoinTossInferNetEngine, bool> condition = null)
    {
        FirstHead = IsHead;
        SecondHead = IsHead;
        BothHeads = FirstHead & SecondHead;

        condition?.Invoke(this);

        FirstCoinPercentage = Math.Round(100.0 * inferenceEngine.Infer<Bernoulli>(FirstHead).GetProbTrue(), 2);
        SecondCoinPercentage = Math.Round(100.0 * inferenceEngine.Infer<Bernoulli>(SecondHead).GetProbTrue(), 2);
        BothCoinsPercentage = Math.Round(100.0 * inferenceEngine.Infer<Bernoulli>(BothHeads).GetProbTrue(), 2);
    }
}