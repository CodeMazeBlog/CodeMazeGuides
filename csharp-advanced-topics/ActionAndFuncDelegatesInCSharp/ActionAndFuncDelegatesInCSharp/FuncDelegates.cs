namespace ActionAndFuncDelegatesInCSharp;

public class FuncDelegates
{
    public static void FuncDelegatesUsage()
    {
        Func<string, string, string> greetWithNameFirst = new Func<string, string, string>(GreetWithName);
        Console.WriteLine(greetWithNameFirst("Ralph", "Nyoni"));
        Func<string, string, string> greetWithNameSecond = GreetWithName;
        Console.WriteLine(greetWithNameSecond("Nyoni", "Ralph"));
    }
    public static string GreetWithName(string firstName, string lastName)
    {
        return $"Hello: {firstName + ' ' + lastName}";
    }
}