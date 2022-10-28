using System;

public class Program
{
    public static void Main(string[] args)
    {
        Func<int> getRandomNumber = delegate ()
        {
            Random rnd = new Random();
            return rnd.Next(1, 100);
        };
        Console.WriteLine(getRandomNumber());
    }
}
