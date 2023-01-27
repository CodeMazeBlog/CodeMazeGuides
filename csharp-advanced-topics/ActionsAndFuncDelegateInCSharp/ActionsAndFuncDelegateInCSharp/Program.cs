public class Program
{
    public int sum;

    //Action Delegate
    public Action<int, int> addition;

    //Func Delegate
    public Func<int, int, int> multiply;

    public static void Main(string[] args)
    {
        Program program = new Program();
        //Action Delegate
        program.addition = program.AddNumbers;
        program.addition(10, 20);
        Console.WriteLine($"[Action Delegate] Addition = {program.sum}");

        //Action Delegate using anonymous method
        program.addition = delegate (int no1, int no2) { program.sum = no1 + no2; };
        program.addition(20, 20);
        Console.WriteLine($"[Action Delegate] Addition using anonymous method = {program.sum}");

        //Action Delegate using Lamda Functions
        program.addition = (no1, no2) => program.sum = no1 + no2;
        program.addition(30, 20);
        Console.WriteLine($"[Action Delegate] Addition using Lambda Function = {program.sum}");

        //Func Delegate
        program.multiply = program.MultiplyNumbers;
        int result = program.multiply(10, 20);
        Console.WriteLine($"[Func Delegate] Multiplication of two numbers = {result}");

        //Func Delegate using Anonymous Method
        program.multiply = delegate (int no1, int no2)
        {
            return no1 * no2;
        };
        int multiplicationResult = program.multiply(20, 20);
        Console.WriteLine($"[Func Delegate] Multiplication of two numbers using anonymous method = {multiplicationResult}");

        //Func Delegate using Lambda Function
        program.multiply = (no1, no2) => no1 * no2;
        multiplicationResult = program.multiply(30, 20);
        Console.WriteLine($"[Func Delegate] Multiplication of two numbers using Lambda Function = {multiplicationResult}");
    }

    private void AddNumbers(int no1, int no2)
    {
        sum = no1 + no2;
    }

    private int MultiplyNumbers(int no1, int no2)
    {
        return no1 * no2;
    }
}