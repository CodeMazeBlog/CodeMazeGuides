using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCsharp;

public class BasketballCounter
{
    private int _scoreCount;

    public void UpdateScore(Func<int, int> incrementor)
    {
        int newScore = incrementor(_scoreCount);
        _scoreCount = newScore;
    }

    public void ShowScore(Action<int> displayer)
    {
        displayer(_scoreCount);
    }
}

