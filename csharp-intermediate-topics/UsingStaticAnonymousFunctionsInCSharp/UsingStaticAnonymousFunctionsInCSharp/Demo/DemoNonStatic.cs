﻿namespace UsingStaticAnonymousFunctionsInCSharp.Demo;

// non-static anonymous function
public class DemoNonStatic
{
    private double numberInEnclosingScope = 4;

    void Calculate(Func<double, double> func)
    {
        Console.WriteLine(func(6));
    }

    public void Display()
    {
        Calculate(num => Math.Pow(numberInEnclosingScope, num));
    }
}