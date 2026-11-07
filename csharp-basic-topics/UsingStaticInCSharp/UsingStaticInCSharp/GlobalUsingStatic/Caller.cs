using static UsingStaticInCSharp.GlobalUsingStatic.Scores;

namespace UsingStaticInCSharp.GlobalUsingStatic;
public class Caller
{
    public virtual void Invoke()
    {
        var hypotenuse = Sqrt(Pow(3, 2) + Pow(4, 2));
        Console.WriteLine("The hypotenuse is {0}", hypotenuse);

        var best = Scores.Max(3, 9);
        Console.WriteLine("The best score is {0}", best);

        // Error CS0121 The call is ambiguous
        // between the following methods or properties:
        // 'System.Math.Max(int, int)' and 'UsingStaticInCSharp.GlobalUsingStatic.Scores.Max(int, int)'
        // var best = Max(3, 9);
    }
}
