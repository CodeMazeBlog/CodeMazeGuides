namespace ActionAndFuncDelegatesInCSharp
{
public class Program
{
    static void Main(string[] args)
    {
        var triangle = new Triangle();
        Console.WriteLine(triangle.AreaDelegate.Invoke(5, 2));

        var circle = new Circle();
        circle.CircumferenceDelegate.Invoke(2);
        Console.WriteLine(circle.Result);
    }
}
}