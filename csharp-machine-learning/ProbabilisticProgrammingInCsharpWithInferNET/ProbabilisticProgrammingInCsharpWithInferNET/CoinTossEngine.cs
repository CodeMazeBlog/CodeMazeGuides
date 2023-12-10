using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProbabilisticProgrammingInCsharpWithInferNET
{
    public class CoinTossEngine
    {
        Random random = new Random();
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
            for (int i = 0; i < numberOfRuns; i++)
            {
                FirstHead = random.NextDouble() > 0.5;
                SecondHead = random.NextDouble() > 0.5;
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

        private bool IsHead { get { return random.NextDouble() > 0.5; } }
    }
}
