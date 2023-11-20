public class Program
{
    static void Main(string[] args)
    {
        FuncDelegateSample();

        Console.WriteLine($"\n");

        ActionDelegateSample();


    }

    public static void ActionDelegateSample()
    {
        //Declaration 
        Action<string> PrintMessage = message =>
        {
            Console.WriteLine(message);
        };
        //Delegate Invocation: 
        PrintMessage("Hello, invoking the delegate!");
    }
    public static void FuncDelegateSample()
    {
        //Declaration 
        Func<double, double> calArea = r =>
        {
            return 3.12 * r * r;
        };

        //Delegate Invocation 
        double Area = calArea(20);

        Console.WriteLine(Area);
    }
}