using static UsingStaticInCSharp.MemberPrecedence.ClassA;

namespace UsingStaticInCSharp.MemberPrecedence;
public class Caller
{
    public virtual void Invoke()
    {
        Console.WriteLine("Describe() returned {0}", Describe());
    }

    private static string Describe() => "Caller.Describe()";
}
