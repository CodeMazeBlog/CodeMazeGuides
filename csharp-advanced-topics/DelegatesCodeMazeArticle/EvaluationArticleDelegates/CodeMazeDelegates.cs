public class CodeMazeDelegates
{
    public double ReturnsTheTotalSum(int x, float y, double z)
    {
        if (x <= 0 || y <= 0 || z <= 0)
        {
            return 0;
        }

        return x + y + z;
    }

    public void PrintsTheTotalSum(int x, float y, double z)
    {
        if (x <= 0 || y <= 0 || z <= 0)
        {
            throw new ArgumentException("All the input values must be greater than 0");
        }

        Console.WriteLine("The Total Sum is : {0}", x + y + z);
    }

    static void Main(string[] args)
    {
        CodeMazeDelegates codeMazeObject = new CodeMazeDelegates();

        Func<int, float, double, double> funcDelegate = codeMazeObject.ReturnsTheTotalSum;
        double result = funcDelegate.Invoke(15, 10.5f, 200.50);
        Console.WriteLine("The Total Sum is : {0}", result);

        Action<int, float, double> actionDelegate = codeMazeObject.PrintsTheTotalSum;
        actionDelegate.Invoke(150, 10.5f, 200.50);

        Console.ReadLine();
    }
}