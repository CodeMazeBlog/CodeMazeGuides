using System;

public class Program
{
public static void Product(int i, int j)
{
    Console.WriteLine(i*j);
}
public static void Main(string[] args)
{
    Action<int,int> dispProduct = Product;
    dispProduct(10,20);
}
    
}

