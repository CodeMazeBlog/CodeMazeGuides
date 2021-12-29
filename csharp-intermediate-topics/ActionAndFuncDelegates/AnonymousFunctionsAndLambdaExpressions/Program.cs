using System;

namespace AnonymousFunctionsAndLambdaExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var calculateAreaOfSquare = delegate (int sideLength) { return sideLength * sideLength; };
        }
    }
}
