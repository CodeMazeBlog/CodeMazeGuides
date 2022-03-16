﻿namespace SumUpArrayElements;

public class Program
{
    private static readonly int[] sourceArray = new int[] { 3, 9, 4, 23, 7, 15, 14, 2, 59, 4 };
    private static readonly SumArrayElements _sumArrayElements = new();
    public static int OutPutResult = 0;

    public static void Main(string[] args)
    {
        Console.WriteLine("-------------------- Sum Up an Array of Integers");
        Console.WriteLine("------------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using For Loop");
        Console.WriteLine($" Result: {_sumArrayElements.ForLoop(sourceArray)}");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using Foreach Loop");
        Console.WriteLine($" Result: {_sumArrayElements.ForeachLoop(sourceArray)}");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using Array.ForEach");
        Console.WriteLine($" Result: {_sumArrayElements.ArrayForEach(sourceArray)}");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using Enumerable.Sum");
        Console.WriteLine($" Result: {_sumArrayElements.EnumerableSum(sourceArray)}");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using array.sum");
        Console.WriteLine($" Result: {_sumArrayElements.ArraySum(sourceArray)}");

        Console.WriteLine();

        Console.WriteLine(" ---------- Using Enumerable.Aggregate");
        Console.WriteLine($" Result: {_sumArrayElements.Aggregate(sourceArray)}");

        Console.WriteLine();
        Console.WriteLine("------------------------------------------------");

        OutPutResult = 1;
    }
}