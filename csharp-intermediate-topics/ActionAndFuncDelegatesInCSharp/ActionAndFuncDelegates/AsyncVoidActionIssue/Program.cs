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

            Thread.Sleep(1200); // wait for myAsyncAction to complete 
        }
        catch (Exception ex)
        {
            // will not catch the exception and the application will crash
        }
    }
}