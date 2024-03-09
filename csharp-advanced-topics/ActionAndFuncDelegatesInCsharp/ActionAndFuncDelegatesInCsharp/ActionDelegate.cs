namespace ActionAndFuncDelegatesInCsharp;

public class ActionDelegate
{
    private delegate void Callback();

    public  static string Message { get; private set; } = string.Empty;
    
    private static void CallbackMethod()
    {
        Message = "Hello World";
    }

    private static void CallbackMethod(string msg)
    {
        Message = msg;
    }
    
    public static void DelegateOperator()
    {
        Callback handler = CallbackMethod;
        handler();
    }
    
    public static void Action()
    {
        Action handler = CallbackMethod;
        handler();
    }

    public static void GenericAction()
    {
        Action<string> handler = CallbackMethod;
        handler("Hello World");
    }

    public static void ActionWithAnonymousMethod()
    {
        Action<string> onSuccess = delegate(string s) { Message = s; };
        onSuccess("Success message"); 
    }

    public static void ActionWithLambdaExpression()
    {
        Action<string> onSuccess = s => Message = s; 
        onSuccess("Success message");
    }
}

