tes 

using System;
class mydelegate
{

    // DEFINING A METHOD AND PARAMETERS
    public static void actiondelegate(int x, int y)
    {
        Console.WriteLine(x + y);
    }

    static public void actiondelegate()
    {

        // Using the action delegate
        Action<int, int> val = actiondelegate;
        val(20, 5);
    }
}


public class myfuncdelegate
{
    static Func<int, int, int> operation;
    public static int Sum(int x, int y) { return x + y; }
    public static void Main()
    {
        Func<int, int, int> add = Sum; int result = add(10, 10);
        Console.WriteLine(result);
    }
}
