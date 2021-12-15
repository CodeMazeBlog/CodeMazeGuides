namespace FuncActionDelegate;

public static class CandidateManager
{
    public static bool CheckExperience(Candidate candidate)
    {
        return candidate.Experience >= 3; // 5 scores
    }

    public static bool CheckAge(Candidate candidate)
    {
        return candidate.Age < 40; // 5 scores
    }

    public static void DisplayScore(Candidate candidate, int score)
    {
        Console.WriteLine($"{candidate.Name}'s score is {score}");
    }

    public static void EvaluateCandidates(List<Candidate> candidates, List<Func<Candidate, bool>> checks, Action<Candidate, int> displayScore)
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
}