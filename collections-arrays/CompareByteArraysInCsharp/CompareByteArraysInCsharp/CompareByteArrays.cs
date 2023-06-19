using BenchmarkDotNet.Attributes;
using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CompareByteArraysInCsharp
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class CompareByteArrays
    {
        private readonly Random _rand;
        private readonly byte[] _byteArray;  

        public CompareByteArrays()
        {
            _rand = new Random();
            _byteArray = GenerateRandomArray(10000000);
        }

        public IEnumerable<object[]> SampleByteArray()
        {
            yield return new object[] { GenerateRandomArray(10000000), GenerateRandomArray(10000000) };
            yield return new object[] { _byteArray, _byteArray };
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingSequenceEqual(byte[] firstArray, byte[] secondArray)
        {
            return firstArray.SequenceEqual(secondArray);
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingExcept(byte[] firstArray, byte[] secondArray)
        {
            var onlyFirst = firstArray.Except(secondArray);
            var onlySecond = secondArray.Except(firstArray);

            return !onlyFirst.Any() && !onlySecond.Any();
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingForLoop(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
            {
                return false;
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    return false;
                }
            }

            return true;
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingHash(byte[] firstArray, byte[] secondArray) 
        {
            using (var hashInstance = SHA256.Create()) 
            {
                var hashFirstArray = hashInstance.ComputeHash(firstArray);
                var hashSecondArray = hashInstance.ComputeHash(secondArray);

                return hashFirstArray.SequenceEqual(hashSecondArray);
            }
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingBinaryEquality(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
                return false;

            unsafe
            {
                fixed (byte* ptr1 = firstArray, ptr2 = secondArray)
                {
                    byte* bptr1 = ptr1;
                    byte* bptr2 = ptr2;
                    var length = firstArray.Length;

                    for (int i = 0; i < length; i++)
                    {
                        if (*bptr1 != *bptr2)
                            return false;

                        bptr1++;
                        bptr2++;
                    }
                }
            }

            return true;
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingIStructuralEquatable(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
                return false;

            return StructuralComparisons.StructuralEqualityComparer.Equals(firstArray, secondArray);
        }

        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int memcmp(byte[] firstArray, byte[] secondArray, int size);
        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingPInvoke(byte[] firstArray, byte[] secondArray)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
                return false;

            return memcmp(firstArray, secondArray, firstArray.Length) == 0;
        }

        private byte[] GenerateRandomArray(int size) 
        {
            var byteArray = new byte[size];

            _rand.NextBytes(byteArray);

            return byteArray;
        }
    }
}
