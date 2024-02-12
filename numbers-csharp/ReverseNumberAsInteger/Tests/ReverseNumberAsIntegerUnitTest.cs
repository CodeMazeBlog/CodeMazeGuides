using ReverseNumberAsInteger;
using System.Numerics;
using Xunit.Abstractions;

namespace Tests
{
    public class ReverseNumberAsIntegerUnitTest(ITestOutputHelper outputHelper)
    {
        private readonly ITestOutputHelper _output = outputHelper;

        [Theory]
        [InlineData(0,0)]
        [InlineData(-1, -1)]
        [InlineData(7,7)]
        [InlineData(-10,-1)]
        [InlineData(12345,54321)]
        [InlineData(2147483647,0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenUsingDigitExtractAndReconstructMethod_ThenNoError(int num, int expectedResult)
        {            
            int actualResult = ReverseNumbers.ReverseUsingDigitExtractionAndReconstruction(num);

            _output.WriteLine($"This test validates Digit Extraction and Recontruction method to reverse a number an integer");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(7, 7)]
        [InlineData(-10, -1)]
        [InlineData(2147483647, 0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenUsingMathPowMethod_ThenNoError(int num, int expectedResult)
        {
            int actualResult = ReverseNumbers.ReverseUsingMathPow(num);

            _output.WriteLine($"This test validates MathPow() method to reverse a number as an integer");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(7, 7)]
        [InlineData(-10, -1)]
        [InlineData(2147483647, 0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenUsingRecursionMethod_ThenNoError(int num, int expectedResult)
        {
            int actualResult = ReverseNumbers.ReverseUsingRecursion(num);

            _output.WriteLine($"This test validates Recursion method to reverse a number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(7, 7)]
        [InlineData(-10, -1)]
        [InlineData(2147483647, 0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenUsingLinqMethod_ThenNoError(int num, int expectedResult)
        {
            int actualResult = ReverseNumbers.ReverseUsingLinq(num);

            _output.WriteLine($"This test validates Linq method to reverse a number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(7, 7)]
        [InlineData(-10, -1)]
        [InlineData(2147483647, 0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenUsingSwappingDigitsMethod_ThenNoError(int num, int expectedResult)
        {
            int actualResult = ReverseNumbers.ReverseBySwappingDigits(num);

            _output.WriteLine($"This test validates Swapping Digits method to reverse a number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(-1, -1)]
        [InlineData(7, 7)]
        [InlineData(-10, -1)]
        [InlineData(2147483647, 0)]
        [InlineData(2147483640, 463847412)]
        [InlineData(-2147483648, 0)]
        [InlineData(-2147483647, 0)]
        [InlineData(-2147483640, -463847412)]
        public void GivenEdgeCases_WhenReversingAsString_ThenNoError(int num, int expectedResult)
        {
            int actualResult = ReverseNumbers.ReverseAsString(num);

            _output.WriteLine($"This test validates reverse as string method to reverse a number as a string.");

            Assert.StrictEqual(expectedResult, actualResult);
        }


        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenUsingDigitExtractAndReconstructMethod_ThenNoError(string str, string expectedResultStr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultStr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseUsingDigitExtractionAndReconstruction(num);

            _output.WriteLine($"This test validates Digit Extraction and Recontruction method to reverse a large number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenUsingMathPowMethod_ThenNoError(string str, string expectedResultStr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultStr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseUsingMathPow(num);
           
            _output.WriteLine($"This test validates MathPow() method to reverse a large number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenUsingRecursionMethod_ThenNoError(string str, string expectedResultstr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultstr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseUsingRecursion(num);
            
            _output.WriteLine($"This test validates Recursion method to reverse a large number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenUsingLinqMethod_ThenNoError(string str, string expectedResultstr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultstr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseUsingLinq(num);
            
            _output.WriteLine($"This test validates Linq method to reverse a large number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenUsingSwappingDigitsMethod_ThenNoError(string str, string expectedResultstr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultstr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseBySwappingDigits(num);
            
            _output.WriteLine($"This test validates Swapping digits method to reverse a large number as an integer.");

            Assert.StrictEqual(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("1234500309480945804890555512324447866666", "6666687444232155550984085490849030054321")]
        [InlineData("-919293847576943309435893857695833", "-338596758398534903349675748392919")]
        [InlineData("5055919293847576965498454987546498784649879845416546565466516516549847651100000000000000000000000000000000000", "11567489456156156645656456145489789464878946457894548945696757483929195505")]
        public void GivenLargeNumber_WhenReversingAsString_ThenNoError(string str, string expectedResultstr)
        {
            BigInteger num = BigInteger.Parse(str);

            BigInteger expectedResult = BigInteger.Parse(expectedResultstr);

            BigInteger actualResult = ReverseLargeNumbers.ReverseAsString(num);

            _output.WriteLine($"This test validates reversing as string method to reverse a large number as a string.");

            Assert.StrictEqual(expectedResult, actualResult);
        }
    }
}