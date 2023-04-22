var delegates = new Delegates();

Console.WriteLine("Running Action Delegates");
delegates.SampleAction_1();
delegates.SampleAction_2();

Console.WriteLine();
Console.WriteLine("Running Func Deleagates");
delegates.SampleFunc_1();
delegates.SampleFunc_2();

Console.WriteLine();
Console.WriteLine("Press any key to exit");
Console.ReadKey();

public class Delegates
{
    public void SampleAction_1()
    {
        //👇 First and second arguments are integers
        Action<int, int> WriteSumOfDelegate = (operator1, operator2) =>
        {
            Console.WriteLine("Sum of {0} and {1} is {2}", operator1, operator2, operator1 + operator2);
        };

        WriteSumOfDelegate(10, 20); //Output: "Sum of 10 and 20 is 30"
    }

    static void WriteDoubleOfAction(int operator1)
    {
        int doubleOf = operator1 * 2;
        Console.WriteLine($"The Double of {operator1} is {doubleOf}");
    }

    public void SampleAction_2()
    {
        //Using class defined Method
        Action<int> WriteDoubleOfDelegate = WriteDoubleOfAction;
        WriteDoubleOfDelegate(10); //The Double of 10 is 20
    }



    public void SampleFunc_1()
    {
        Func<int, int> DoubleItDelegate = (operator1) =>
        {
            return operator1 * 2;
        };
        var result = DoubleItDelegate(2); //returns 4
        Console.WriteLine("Func Double result {0}", result); //Output: "Func Double result 4"
    }

    public void SampleFunc_2()
    {
        //Using class defined Method
        Func<int, int> TripleDelegate = Delegates.TripleItFunc;
        var tripleResult = TripleDelegate(2); //returns 6

        //Output: "Func TripleDelegate with Argument 2 is 6"
        Console.WriteLine($"Func TripleDelegate with Argument {2} is {tripleResult}");
    }

    static int TripleItFunc(int operator1) => operator1 * 3;
}