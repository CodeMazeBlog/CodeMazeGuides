namespace Action_Func
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActionExample.Calculate(20, 10);

            (int sum, int subtract) = FuncExample.Calculate(20, 10);
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Subtract: {subtract}");

            FuncExample.LinqExamples();
        }
    }
}