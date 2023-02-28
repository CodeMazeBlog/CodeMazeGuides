using System;

public class Test

{

    public static void Main(string[] args)
    {

        Action<int> First = One;

        Action<string, string> Second = Two;

        First(14);

        Second("Action", "Generic");

    }

    public static void One(int a)
    {

        Console.WriteLine(a);

    }

    public static void Two(string a, string b)
    {

        Console.WriteLine(a + b);

    }

}