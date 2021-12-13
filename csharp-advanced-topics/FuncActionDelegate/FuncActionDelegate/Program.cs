public class Program
{
    public class Candidate
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
    }

    private static bool CheckExperience(Candidate candidate)
    {
        return candidate.Experience >= 3; // 5 scores
    }

    private static bool CheckAge(Candidate candidate)
    {
        return candidate.Age < 40; // 5 scores
    }

    private static void DisplayScore(Candidate candidate, int score)
    {
        Console.WriteLine($"{candidate.Name}'s score is {score}");
    }

    private static void EvaluateCandidates(List<Candidate> candidates, List<Func<Candidate, bool>> checks, Action<Candidate, int> displayScore)
    {
        foreach (var candidate in candidates)
        {
            int score = 0;

            foreach (var check in checks)
            {
                if (check(candidate))
                    score += 5;
            }

            displayScore(candidate, score);
        }
    }

    public static void Main(string[] args)
    {
        var candidates = new List<Candidate>
        {
            new() { Name = "David",Age = 20,Experience = 5},
            new() { Name = "Alex",Age = 42,Experience = 10},
            new() { Name = "Bill",Age = 45,Experience = 1}
        };

        Action<Candidate, int> displayScoreAction = DisplayScore;

        var checkFuncDelegates = new List<Func<Candidate, bool>> { CheckAge, CheckExperience };

        EvaluateCandidates(candidates, checkFuncDelegates, displayScoreAction);

        Console.ReadKey();
    }
}