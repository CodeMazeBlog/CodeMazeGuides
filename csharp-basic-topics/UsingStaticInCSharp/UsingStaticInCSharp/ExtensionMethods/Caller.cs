using static UsingStaticInCSharp.ExtensionMethods.DifferentNamespace.NumberExtensions;

namespace UsingStaticInCSharp.ExtensionMethods;
public class Caller
{
    public virtual void Invoke()
    {
        var sum = 1.Add(2);
        Console.WriteLine("The sum is {0}", sum);
    }
}
