namespace DelegatesActionAndFunc;

public static class Program
{
    public static string Capitalize(string input)
    {
        return string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
    }

    public static void LogCurrentUTCDateTime()

    {
        Console.WriteLine($"Current date time is {DateTime.Now}");
    }

    public static void Main()
    {
        #region Action type delegate
        Action writeCurrentTimeDelegate = () => Console.WriteLine($"Current date time is {DateTime.Now}");
        writeCurrentTimeDelegate();

        #endregion

        #region Func type delegate
        string myName = "john";
        Func<string, string> capitalizeDelegate = Capitalize;
        Console.WriteLine(capitalizeDelegate(myName)); //prints "John"
        #endregion
    }
}