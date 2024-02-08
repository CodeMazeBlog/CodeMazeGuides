namespace AsyncVoidActionIssue;

public class Program
{
    static void Main(string[] args)
    {
        Action<int> myAsyncAction = async (milliseconds) =>
        {
            await Task.Delay(milliseconds);
            throw new Exception("I broke your application!");
        };

        try
        {
            myAsyncAction(1000);

            Thread.Sleep(1200);
        }
        catch (Exception ex)
        {
        }
    }
}