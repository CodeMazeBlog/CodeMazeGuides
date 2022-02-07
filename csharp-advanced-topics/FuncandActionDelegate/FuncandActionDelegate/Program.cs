// See https://aka.ms/new-console-template for more information
Console.WriteLine("Func and Action in C#");

public partial class Program
{
    //Method that Targets Func Delegate
    public static int Multiply(int x, int y) => x * y;

    //Method that Targets Action Delegate
    public static void DisplayMessage(string message) => Console.WriteLine(message);

    public static void Run()
    {
        var program = new Program();
        program.InvokeMultiplication(5, 10);
        program.InvokeDisplay();

        Console.ReadLine();
    }

   public bool InvokeDisplay() 
   { 
        Action<string> actionTarget = DisplayMessage; 
        actionTarget("***** Fun with Action *****");
        return true; 
   }

    public int InvokeMultiplication(int x,int y)
    {
        Func<int, int, int> funcTarget = Multiply;
        var response = funcTarget.Invoke(x, y);
        Console.WriteLine("Multiplication = {0}", response);
        return response;
    } 
}
