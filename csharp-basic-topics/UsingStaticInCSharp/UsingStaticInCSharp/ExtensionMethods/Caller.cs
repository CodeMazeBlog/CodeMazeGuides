using static UsingStaticInCSharp.ExtensionMethods.DifferentNamespace.NumberExtensions;

namespace UsingStaticInCSharp.ExtensionMethods;
public static class Caller
{
    public static void Invoke()
    {
        var sum = 1.Add(2);
        Console.WriteLine("The sum is {0}", sum);
    }
}
