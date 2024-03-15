namespace ExceptionHandlingInCSharp.Exceptions;

public static class GlobalExceptionHandler
{
    public static void HandleException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is not Exception exception) 
        {
            return;
        }
        
        Console.WriteLine("Global Exception Handler caught an exception: " + exception.Message);
    }
}
