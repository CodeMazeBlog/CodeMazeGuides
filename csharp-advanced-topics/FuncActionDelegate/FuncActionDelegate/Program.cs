namespace FuncActionDelegate;

public class Program
{
    public static void Main()
    {
        var candidates = new List<Candidate>
        {
            new() { Name = "David", Age = 20, Experience = 5 },
            new() { Name = "Alex", Age = 42, Experience = 10 },
            new() { Name = "Bill", Age = 45, Experience = 1 }
        };

        Action<Candidate, int> displayScoreAction = CandidateManager.DisplayScore;

        var checkFuncDelegates = new List<Func<Candidate, bool>> { CandidateManager.CheckAge, CandidateManager.CheckExperience };

        CandidateManager.EvaluateCandidates(candidates, checkFuncDelegates, displayScoreAction);

        Console.ReadKey();
    }
}