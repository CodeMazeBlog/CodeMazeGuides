namespace AsyncVoidActionIssue;

public class Program
{
    static void Main(string[] args)
    {
        // This is non-unit testable code 

        Action<int> myAsyncAction = async (milliseconds) =>
        {
            await Task.Delay(milliseconds);  // Simulate some async work

            throw new Exception("I broke your application!"); // simulate exception
        };

        try
        {
            myAsyncAction(1000);
        }
        catch (Exception ex)
        {
            // will not catch the exception and the application will crash
        }
    }
}