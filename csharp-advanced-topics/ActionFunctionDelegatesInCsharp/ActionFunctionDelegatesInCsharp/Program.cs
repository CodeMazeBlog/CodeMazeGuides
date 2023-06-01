public delegate void MyGenericDelegate<T>(T obj);

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("***** Generic Delegates *****\n"); 
      
        MyGenericDelegate<string> myGeneric = DisplayName;
        myGeneric("Bob");

        Console.WriteLine("***** Generic Delegates *****\n"); 

        Action<string> displayNameAct = DisplayName; 
        displayNameAct("Bob");

        Console.WriteLine("***** Function *****\n");

        Func<int, string> toStringFunc = NumberToString;
        toStringFunc(4);
        Func<int, double> toDoubleFunc = NumberToDouble;
        toDoubleFunc(4);

    }
    public static void DisplayName(string name) 
    { 
        Console.WriteLine($"My name is {name}"); 
    }
    public static string NumberToString(int number)
    {
        return number.ToString();
    }
    public static double NumberToDouble(int number)
    {
        return Convert.ToDouble(number);
    }
}

