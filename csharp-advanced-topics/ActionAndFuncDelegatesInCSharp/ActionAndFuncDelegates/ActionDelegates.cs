using System;

public static class ActionDelegates
{
    public static void LogInformation(string info)
    {
        //Action<string> log = (infoDetail) => 
        Console.WriteLine($"This logs some {info} to the console");
        //log(info);
    }
    public static void LoggError(string error)
    {
        //Action<string> log = (errorDetail) => 
        Console.WriteLine($"This logs the {error} to the console");
        //log(error);
    }  
}
