namespace DefaultValuesForLambdaExpressions;

public class ExampleCases
{
    public static string GreetUserWithDefaultValue()
    {
        var greetUser = (string name = "User") => $"Hello, {name}!";

        return greetUser();
    }

    public static string GreetUserWithName()
    {
        var greetUser = (string name = "User") => $"Hello, {name}!";

        return greetUser("Peter");
    }

    public static string GreetTeamWith3Members()
    {
        var greetTeam = (params string[] members) => $"Hello, team: {string.Join(", ", members)}.";

        return greetTeam("John", "Peter", "Isaac");
    }

    public static string GreetTeamWith5Members()
    {
        var greetTeam = (params string[] members) => $"Hello, team: {string.Join(", ", members)}.";

        return greetTeam("John", "Peter", "Isaac", "Theo", "Matteo");
    }
}
