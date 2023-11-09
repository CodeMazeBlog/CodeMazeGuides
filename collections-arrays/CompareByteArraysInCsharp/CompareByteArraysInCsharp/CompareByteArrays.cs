using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using System.Collections;
using System.Numerics;
using System.Runtime.InteropServices;

namespace CompareByteArraysInCsharp
{
    [MemoryDiagnoser]
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByParams)]
    public class CompareByteArrays
    {
        private readonly Random _rand;

        public CompareByteArrays()
        {
            _rand = new Random();
        }

        public IEnumerable<object[]> SampleByteArray()
        {
            yield return new object[] { GenerateOrderedArray(true, false, 10000000), GenerateOrderedArray(true, false, 10000000), "Best Case" };
            yield return new object[] { GenerateOrderedArray(false, true, 10000000), GenerateOrderedArray(false, true, 10000000), "Average Case" };
            yield return new object[] { GenerateOrderedArray(false, false, 10000000), GenerateOrderedArray(false, false, 10000000), "Worst Case" };
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingSequenceEqual(byte[] firstArray, byte[] secondArray, string arrayName)
        {
            return firstArray.SequenceEqual(secondArray);
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingExcept(byte[] firstArray, byte[] secondArray, string arrayName)
        {
            var onlyFirst = firstArray.Except(secondArray);
            var onlySecond = secondArray.Except(firstArray);

            return !onlyFirst.Any() && !onlySecond.Any();
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingForLoop(byte[] firstArray, byte[] secondArray, string arrayName)
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
        public unsafe bool CompareUsingBinaryEquality(byte[] firstArray, byte[] secondArray, string arrayName)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
                return false;

            var arrayLength = firstArray.Length;
            var vectorSize = Vector<byte>.Count;

            fixed (byte* pbtr1 = firstArray, pbtr2 = secondArray)
            {
                var i = 0;

                for (; i <= arrayLength - vectorSize; i += vectorSize)
                {
                    if (!VectorEquality(pbtr1 + i, pbtr2 + i))
                        return false;
                }

                for (; i < arrayLength; i++)
                {
                    if (pbtr1[i] != pbtr2[i])
                        return false;
                }
            }

            return true;
        }

        private unsafe bool VectorEquality(byte* firstPointer, byte* secondPointer)
        {
            var firstVector = *(Vector<byte>*)firstPointer;
            var secondVector = *(Vector<byte>*)secondPointer;

            return Vector.EqualsAll(firstVector, secondVector);
        }

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingIStructuralEquatable(byte[] firstArray, byte[] secondArray, string arrayName)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
                return false;

            return StructuralComparisons.StructuralEqualityComparer.Equals(firstArray, secondArray);
        }

#if NET
        [DllImport("msvcrt", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int memcmp(byte[] firstArray, byte[] secondArray, long size);
#else
        [DllImport("libc", CallingConvention = CallingConvention.Cdecl, SetLastError = true)]
        private static extern int memcmp(byte[] firstArray, byte[] secondArray, ulong size);
#endif

        [ArgumentsSource(nameof(SampleByteArray))]
        [Benchmark]
        public bool CompareUsingPInvoke(byte[] firstArray, byte[] secondArray, string arrayName)
        {
            if (firstArray == null || secondArray == null || firstArray.Length != secondArray.Length)
            {
                return false;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return memcmp(firstArray, secondArray, firstArray.Length) == 0;
            }

            else
            {
                return memcmp(firstArray, secondArray, firstArray.Length) == 0;
            }
        }

        private unsafe byte[] GenerateOrderedArray(bool firstElement, bool middleElement, int size)
        {
            var byteArray = new byte[size * sizeof(int)];

            fixed (byte* bytePtr = byteArray)
            {
                int* intPtr = (int*)bytePtr;

                for (int i = 0; i < size; i++)
                {
                    if (firstElement && i == 0)
                    {
                        intPtr[i] = _rand.Next();
                    }
                    else if (middleElement && i == (size / 2))
                    {
                        intPtr[i] = _rand.Next();
                    }
                    else
                    {
                        intPtr[i] = i;
                    }
                }
            }

            return byteArray;
        }

        public (byte[] array1, byte[] array2, byte[] array3) GenerateTestArrays()
        {
            var rand = new Random(42);
            var array1 = new byte[Vector<byte>.Count * 2 + 3];
            rand.NextBytes(array1);
            var span = array1.AsSpan();
            var array2 = new byte[array1.Length];
            span.CopyTo(array2);
            array2[array2.Length / 2] = (byte)(-array2[array2.Length / 2]);
            var array3 = new byte[array1.Length];
            span.CopyTo(array3);
            array3[^1] = (byte)(-array3[^1]);

            return (array1, array2, array3);
        }
    }
}