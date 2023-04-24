namespace ActionAndFuncInCsharpConsole;
using  System;
public class ActionExamples
{
    public void Print()
    {
        Console.WriteLine("logging message");
    }

    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    private Action Logger;
    private Action<string> LoggerInfo;
    private Action<string, string> Notify;
    
    
    public void Compute(Action LoggerInfo)
    {
        // do some work  
        Console.WriteLine("Operation started");
       
    }

    public void Compute2(System.Action<string> LoggerInfo )
    {
        LoggerInfo("Starting Job");
        LoggerInfo("Job Operation Completed");
    }

    public void SendMessage(string message, string to, System.Action<string, string> Notify)
    {
        Notify(message, to);
    }
    
    public void DoSomeWork()
    {
        
        var message = "hello work done";
        var phone = "+1233333333";
        var email = "example@x.com"; 
        SendMessage(message, phone, SendSms);
        SendMessage(message, phone, SendEmail);
    }

    private void SendEmail(string message, string email)
    {
        // send some email
        Console.WriteLine("send email completed");
    }
    
    private void SendSms(string message, string phone)
    {
        // send some email 
        Console.WriteLine("send sms completed");
    }
    
    public void DoSomeWork2()
    {
        Compute2(Print);
       
    }
    
    // Action delegate with 0 parameters
    public delegate void Action();

    // Action delegate with 1 parameter
    public delegate void Action<T>(T obj);

    // Action delegate with 2 parameters
    public delegate void Action<T1, T2>(T1 arg1, T2 arg2);
    
    // ... up to 16 parameters

}