namespace ActionAndFuncInCsharpConsole;

public class FuncExample
{


    

    
    // Func with 0 parameter 
    public delegate TResult Func<out TResult>();
    
    // Func with 1 parameter
    public delegate TResult Func<in T, out TResult>(T arg);
    
    // Func with 2 Parameter 
    public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
    // ... up to 16 input parameters
    
    // Define a Func delegate with no input parameters and an integer return type 
    
   public Func<int> GetRandomNumber = () => new Random().Next(1, 101); 
    
    private Func<int, int, int> Calculate;
    public int Sum(int a, int b)
    {
        return a + b;
    }

    public int Difference(int a, int b)
    {
        return a - b;
    }

   
    public void PerformCalculate(char operation, int a, int b)
    {
        if (operation == '+')
        {
            Calculate = Sum; 
        }
        else
        {
            Calculate = Difference;
        }

        var result = Calculate(a, b);
        Console.WriteLine(result);
    }

    public void PerformCalculate(int a, int b, System.Func<int, int, int> cal)
    {
        var result = cal(a,b) + 1;
        Console.WriteLine(result);
    }

    public void DoSomeWork()
    { 
        PerformCalculate('+', 3,4);
        PerformCalculate(3, 4, Multiple);
        PerformCalculate(1, 4, Sum);
        PerformCalculate(4, 2, Difference);
        
    }
    
    int Multiple(int a, int b)
    {
        return a * b;
    }
}