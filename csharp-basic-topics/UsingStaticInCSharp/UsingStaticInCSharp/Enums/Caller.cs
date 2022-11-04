using static UsingStaticInCSharp.Enums.Color;

namespace UsingStaticInCSharp.Enums;
public static class Caller
{
    public static void Invoke()
    {
        Console.WriteLine("The enum items are {0}, {1}, {2}", Red, Green, Blue);
    }
}