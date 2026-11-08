using static UsingStaticInCSharp.Constants.Status;

namespace UsingStaticInCSharp.Constants;
public class Caller
{
    public virtual void Invoke()
    {
        Console.WriteLine("The constants are {0}, {1}, {2}", Pending, InProgress, Completed);
    }
}
