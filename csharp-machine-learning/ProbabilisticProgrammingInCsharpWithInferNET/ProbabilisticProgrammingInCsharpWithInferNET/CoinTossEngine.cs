namespace ProbabilisticProgrammingInCsharpWithInferNET;
public class CoinTossEngine
{
    private bool IsHead { get { return Random.Shared.NextDouble() > 0.5; } }
    public bool FirstHead { get; private set; }
    public bool SecondHead { get; private set; }
    public bool BothHeads { get; private set; }

    public int FirstCoinHeadCount { get; private set; }
    public int SecondCoinHeadCount { get; private set; }
    public int BothCoinsHeadCount { get; private set; }
    public int RunCount { get; private set; }

    public double FirstCoinPercentage { get; private set; }
    public double SecondCoinPercentage { get; private set; }
    public double BothCoinsPercentage { get; private set; }

    public void TossTheCoins(int numberOfRuns = 1000000, Func<CoinTossEngine, bool> condition = null)
    {
        RunCount = 0;
        for (int i = 0; i < numberOfRuns; i++)
        {
            FirstHead = IsHead;
            SecondHead = IsHead;
            BothHeads = FirstHead && SecondHead;

            if (condition == null || condition(this))
            {
                if (FirstHead) FirstCoinHeadCount++;
                if (SecondHead) SecondCoinHeadCount++;
                if (BothHeads) BothCoinsHeadCount++;
                RunCount++;
            }
        }
        FirstCoinPercentage = Math.Round(100.0 * FirstCoinHeadCount / RunCount, 2);
        SecondCoinPercentage = Math.Round(100.0 * SecondCoinHeadCount / RunCount, 2);
        BothCoinsPercentage = Math.Round(100.0 * BothCoinsHeadCount / RunCount, 2);
    }

    public int TossCoin(int numberOfRuns = 1000000)
    {
        var headsCount = 0;
        for (int i = 0; i < numberOfRuns; i++)
            if (IsHead)
                headsCount++;

        return headsCount;
    }

    public int[] IsCoinFairExperiments(int numberOfExperiments = 10)
    {
        var headCounts = new List<int>();
        for (int i = 0; i < numberOfExperiments; i++)
            headCounts.Add(TossCoin());

        return headCounts.ToArray();
    }
}