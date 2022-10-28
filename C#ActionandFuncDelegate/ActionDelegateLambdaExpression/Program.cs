using System;

public class Program
{
    public static void Main(string[] args)
    {
        Action<int, int> dispProduct = (i, j) => Console.WriteLine(i * j);
        dispProduct(10, 20);
    }
}