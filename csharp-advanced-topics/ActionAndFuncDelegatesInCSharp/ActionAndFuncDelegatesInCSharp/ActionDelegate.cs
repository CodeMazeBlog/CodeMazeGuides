namespace ActionAndFuncDelegatesInCSharp;

public static class ActionDelegate
{
    public static bool LogUsingActionReferringANamedMethod()
    {
        var isLogged = false;
        
        void LogToConsole(string msg)
        {
            isLogged = true;
        }

        Action<string> logToConsole = LogToConsole;
        logToConsole("hello");

        return isLogged;
    }
    
    public static bool LogUsingActionReferringAnAnonymousMethod()
    {
        var isLogged = false;
        
        Action<string> logToConsole = delegate(string msg)
        {
            isLogged = true;
        };
        
        logToConsole("hello");

        return isLogged;
    }
    
    public static bool LogUsingActionReferringALambdaExpression()
    {
        var isLogged = false;

        Action<string> logToConsole = msg =>
        {
            isLogged = true;
        };
        
        logToConsole("hello");

        return isLogged;
    }

    public static bool CallingActionUsingInvoke()
    {
        var isInvoked = false;
        Action<string> log = msg =>
        {
            isInvoked = true;
        };

        log.Invoke("hello");

        return isInvoked;
    }
    
    public static (bool isLogConsoleInvoked, bool isLogDbInvoked) FormingMulticastDelegateUsingActions()
    {
        var isLogConsoleInvoked = false;
        var isLogDbInvoked = false;

        Action<string> logConsole = msg =>
        {
            isLogConsoleInvoked = true;
        };
        Action<string> logDb = msg =>
        {
            isLogDbInvoked = true;
        };
        Action<string> log = logConsole + logDb;

        log("hello");

        return (isLogConsoleInvoked, isLogDbInvoked);
    }
}