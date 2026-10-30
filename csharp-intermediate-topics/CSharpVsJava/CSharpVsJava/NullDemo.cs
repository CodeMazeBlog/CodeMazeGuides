namespace CSharpVsJava;

public static class NullDemo
{
    public static void RunUnchecked()
    {
        string? email = FindEmail(customerId: 42);
        Console.WriteLine(email.Length);
    }

    public static void Run()
    {
        string? email = FindEmail(customerId: 42);
        Console.WriteLine(email?.Length ?? 0);
    }

    private static string? FindEmail(int customerId) => customerId == 1 ? "ann@example.com" : null;
}
