using BenchmarkDotNet.Running;
using System.Numerics;

namespace ReverseNumberAsInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = [1276345, -12345, 10, 0];
            List<BigInteger> bigNum = [BigInteger.Parse("12345003094809458066"),
                BigInteger.Parse("-9192938475769433833")];

            int reversedNum = 0;
            BigInteger reversedLargeNum = 0;

            foreach (int i in input)
            {
                reversedNum = ReverseNumbers.ReverseUsingDigitExtractionAndReconstruction(i);
                Console.WriteLine("Reverse number using Digit Extraction and Reconstruction method:\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                reversedNum = ReverseNumbers.ReverseUsingModuloAndDivision(i);
                Console.WriteLine("Reverse number using Modulo And Division method:\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                reversedNum = ReverseNumbers.ReverseBySwappingDigits(i);
                Console.WriteLine("Reverse number by swapping digits method:\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                reversedNum = ReverseNumbers.ReverseUsingMathPow(i);
                Console.WriteLine("Reverse number using MathPow():\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                reversedNum = ReverseNumbers.ReverseUsingRecursion(i);
                Console.WriteLine("Reverse number using Recursion method:\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                reversedNum = ReverseNumbers.ReverseUsingLinq(i);
                Console.WriteLine("Reverse number using Linq:\nOriginal Num: {0} Reversed Num: {1}", i, reversedNum);
                Console.WriteLine("\n---------------------------------------------------");
            }

            foreach (BigInteger num in bigNum)
            {
                reversedLargeNum = ReverseLargeNumbers.ReverseUsingDigitExtractionAndReconstruction(num);
                Console.WriteLine("Reverse number using Digit Extraction and Reconstruction method:\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                reversedLargeNum = ReverseLargeNumbers.ReverseUsingModuloAndDivision(num);
                Console.WriteLine("Reverse number using Modulo And Division method:\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                reversedLargeNum = ReverseLargeNumbers.ReverseBySwappingDigits(num);
                Console.WriteLine("Reverse number by swapping digits method:\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                reversedLargeNum = ReverseLargeNumbers.ReverseUsingMathPow(num);
                Console.WriteLine("Reverse number using MathPow():\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                reversedLargeNum = ReverseLargeNumbers.ReverseUsingRecursion(num);
                Console.WriteLine("Reverse number using Recursion method:\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                reversedLargeNum = ReverseLargeNumbers.ReverseUsingLinq(num);
                Console.WriteLine("Reverse number using Linq:\nOriginal Num: {0} Reversed Num: {1}", num, reversedLargeNum);
                Console.WriteLine("\n---------------------------------------------------");
            }

            Console.ReadKey();
        }

        public static void RunBenchmark()
        {
            BenchmarkRunner.Run<BenchmarkReverseNumber>();
            BenchmarkRunner.Run<BenchmarkReverseLargeNumber>();
            BenchmarkRunner.Run<BenchmarkReverseVeryLargeNumber>();
        }
    }
}
