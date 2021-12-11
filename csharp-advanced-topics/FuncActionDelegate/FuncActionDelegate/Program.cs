public class Program
{
    public static void Main(string[] args)
    {
        var developers = new List<Candidate>
        {
            new Candidate("David", 20, 5),
            new Candidate("Alex", 42, 10),
            new Candidate("David", 45, 1)
        };

        EvaluateCandidates(developers, DisplayScore, CheckAge, CheckExperience);

        Console.ReadKey();

    }

    private static void EvaluateCandidates(List<Candidate> candidates, Action<Candidate, int> displayScore, params Func<Candidate, bool>[] checkList)
    {
        foreach (var candidate in candidates)
        {
            int score = 0;

            foreach (var check in checkList)
            {
                if (check(candidate))
                    score += 5;

            }

            displayScore(candidate, score);
        }
    }
    private static bool CheckExperience(Candidate candidate)
    {
        return candidate.Experience >= 3;
    }

    private static bool CheckAge(Candidate candidate)
    {
        return candidate.Age < 40;
    }

    private static void DisplayScore(Candidate candidate, int score)
    {
        Console.WriteLine($"{candidate.Name}'s score is {score}");
    }

}

public class Candidate
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }

    public Candidate(string name, int age, int experience)
    {
        Name = name;
        Age = age;
        Experience = experience;
    }
}
