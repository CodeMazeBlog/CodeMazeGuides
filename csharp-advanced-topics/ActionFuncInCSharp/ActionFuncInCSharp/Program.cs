namespace AsyncFuncInCSharp;

public delegate string Notifier(string message, DateTime notificationTime);

public static class Program
{
    static void Main(string[] args)
    {
        //Simple delegate usage
        var nm = new Notifier(NotifyMe.SendNotification);
        Console.WriteLine(nm("'Simple delegate' started",DateTime.Now));
        Thread.Sleep(1000);
        Console.WriteLine(nm("'Simple delegate' completed",DateTime.Now));

        //Action<T> delegate usage
        var na = new Action<string, DateTime>(ActionDelegate.NotifyMeByAction);
        na("'Action<T>' started", DateTime.Now);
        Thread.Sleep(1000);
        na("'Action<T>' completed",DateTime.Now);

        //Func<T, TResult> delegate usage
        var nf = new Func<string, DateTime, string>(FuncDelegate.NotifyMeByFunc);
        Console.WriteLine(nf("'Func<T, TResult> delegate' started", DateTime.Now));
        Thread.Sleep(1000);
        Console.WriteLine(nf("'Func<T, TResult> delegate' completed",DateTime.Now));

        Console.WriteLine("Press any key to close this window...");
        Console.ReadKey();
    }
}