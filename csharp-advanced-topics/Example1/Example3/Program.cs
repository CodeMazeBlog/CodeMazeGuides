using System;

public class Test

{

    public static void Main()

    {

        Func<int, int, int> Res = Multiply;

        int val = Res(4, 9);

        Console.WriteLine(val);

    }

    public static int Multiply(int a, int b)
    {

        return a * b;

    }

}