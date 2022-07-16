namespace ActionAndFuncDelegatesInCSharp;

public class TransformDemonstration
{
    public delegate int Transform(int input);

    private int Double(int x)
    {
        Console.Write("Calling Double, ");
        return x * 2;
    }

    private int Triple(int x)
    {
        Console.Write("Calling Triple, ");
        return x * 3;
    }

    public void Demonstrate()
    {
        Transform transformer = Double;

        int result = transformer.Invoke(5); // Calling Double,
        Console.WriteLine(result); // 10

        transformer += Triple;

        result = transformer.Invoke(5); // Calling Double, Calling Triple,
        Console.WriteLine(result); // 15

        transformer -= Triple;
        result = transformer.Invoke(5); // Calling Double,
        Console.WriteLine(result); // 10
    }
}