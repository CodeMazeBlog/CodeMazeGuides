namespace FuncAndActionDelegates
{
    public class MethodCollections
    {
        //Methods that takes parameters but returns nothing:
public static void PrintNumbers(int number){
Console.WriteLine($"The number is {number}");
}
public static void MultiplyNumbers(int number){
    number *=2;
Console.WriteLine($"The multiply number is {number}");
}
       
        //Methods that takes parameters and returns a value:

        public static int Addition(int a, int b)
        {
            return a + b;
        }

        
    }
    
}
