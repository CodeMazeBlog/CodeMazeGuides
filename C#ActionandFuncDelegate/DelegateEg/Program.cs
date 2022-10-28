using System;

public class Program
{
    public delegate void Product(int val1, int val2);
    public static void Multiply(int i, int j)
    {
        Console.WriteLine(i * j);
    }
    public static void Main(string[] args)
    {
        Product prod = Multiply;
        prod(5, 100);
    }
}