using static UsingStaticInCSharp.Enums.Role;

namespace UsingStaticInCSharp.Enums;
public class Caller
{
    public virtual void Invoke()
    {
        Console.WriteLine("The enum items are {0}, {1}", User, Admin);
    }
}