namespace ProbabilisticProgrammingInCsharpWithInferNET;
public class CoinTossEngine
{
    private static bool IsHeads => Random.Shared.NextDouble() > 0.5;

    public bool FirstHeads { get; private set; }
    public bool SecondHeads { get; private set; }
    public bool BothHeads { get; private set; }

    public int FirstCoinHeadCount { get; private set; }
    public int SecondCoinHeadCount { get; private set; }
    public int BothCoinsHeadCount { get; private set; }
    public int RunCount { get; private set; }

    public double FirstCoinPercentage { get; private set; }
    public double SecondCoinPercentage { get; private set; }
    public double BothCoinsPercentage { get; private set; }

    public void TossTheCoins(int numberOfRuns = 1_000_000, Func<CoinTossEngine, bool> condition = null)
    {
        RunCount = 0;
        for (int i = 0; i < numberOfRuns; i++)
        {
            FirstHeads = IsHeads;
            SecondHeads = IsHeads;
            BothHeads = FirstHeads && SecondHeads;

            if (condition == null || condition(this))
            {
                if (FirstHeads) FirstCoinHeadCount++;
                if (SecondHeads) SecondCoinHeadCount++;
                if (BothHeads) BothCoinsHeadCount++;
                RunCount++;
            }
        }

        FirstCoinPercentage = Math.Round(100.0 * FirstCoinHeadCount / RunCount, 2);
        SecondCoinPercentage = Math.Round(100.0 * SecondCoinHeadCount / RunCount, 2);
        BothCoinsPercentage = Math.Round(100.0 * BothCoinsHeadCount / RunCount, 2);
    }

    public int TossCoin(int numberOfRuns = 1_000_000)
    {
        var headsCount = 0;
        for (int i = 0; i < numberOfRuns; i++)
            if (IsHeads)
                headsCount++;

        return headsCount;
    }

    public int[] IsCoinFairExperiments(int numberOfExperiments = 10)
    {
        var headCounts = new int[numberOfExperiments];
        for (int i = 0; i < numberOfExperiments; i++)
            headCounts[i] = TossCoin();

        return headCounts;
    }
}