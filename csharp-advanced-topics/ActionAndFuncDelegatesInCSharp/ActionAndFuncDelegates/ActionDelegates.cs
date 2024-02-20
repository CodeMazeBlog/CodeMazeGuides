using System;

public static class ActionDelegates
{
    public static void LogInformation(string info)
    {
        Console.WriteLine($"This logs some {info} to the console");
    }
    public static void LogError(string error)
    {
        Console.WriteLine($"This logs the {error} to the console");
    }  
}
