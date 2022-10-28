using System;

public class Program
{
    public static void Main()
    {
        Func<int> getRandomNumber = () => new Random().Next(1, 100);
        Console.WriteLine(getRandomNumber());
    }
}
