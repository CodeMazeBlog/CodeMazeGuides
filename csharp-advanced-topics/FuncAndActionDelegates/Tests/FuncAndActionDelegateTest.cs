using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FuncAndActionDelegateTest
    {
        [TestMethod]
        public void TestFactorialCalculation()
        {
            // Arrange
            Func<int, int> funcFact = GetFactorial;
            int inputNumber = 7;
            int expectedFactorial = 5040;

            // Act
            int actualFactorial = funcFact(inputNumber);

            // Assert
            Assert.AreEqual(expectedFactorial, actualFactorial, $"Factorial of {inputNumber} should be {expectedFactorial}");
        }

        [TestMethod]
        public void TestPrimeNumberCheck()
        {
            // Arrange
            int inputNumber = 13;
            string expectedOutput = "13 is a Prime Number";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                IsPrimeNumber(inputNumber);
                string actualOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput, $"Expected: {expectedOutput}, Actual: {actualOutput}");
            }
        }

        [TestMethod]
        public void TestStringLengthPrinting()
        {
            // Arrange
            string inputString = "qwerty";
            string expectedOutput = $"Length of {inputString} is {inputString.Length}";

            // Act
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                aCharLen.Invoke(inputString);
                string actualOutput = sw.ToString().Trim();

                // Assert
                Assert.AreEqual(expectedOutput, actualOutput, $"Expected: {expectedOutput}, Actual: {actualOutput}");
            }
        }

        [TestMethod]
        public void TestMultiplicationCalculation()
        {
            // Arrange
            int inputValue1 = 17;
            int inputValue2 = 23;
            int expectedProduct = inputValue1 * inputValue2;

            // Act
            int actualProduct = Multiply(inputValue1, inputValue2);

            // Assert
            Assert.AreEqual(expectedProduct, actualProduct, $"Expected: {expectedProduct}, Actual: {actualProduct}");
        }

        




        // The GetFactorial method is placed within the test class for simplicity
        private int GetFactorial(int factNum)
        {
            int i, fact = 1;

            for (i = 1; i <= factNum; i++)
            {
                fact = fact * i;
            }

            return fact;
        }

        // The original fCalulate delegate is replaced with a Multiply method for testability
        private int Multiply(int x, int y)
        {
            return x * y;
        }

        // The IsPrimeNumber method is placed within the test class for simplicity
        private void IsPrimeNumber(int num)
        {
            int a = 0;

            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    a++;
                }
            }

            if (a == 2)
            {
                Console.WriteLine($"{num} is a Prime Number");
            }
            else
            {
                Console.WriteLine($"{num} is Not a Prime Number");
            }
        }

        // The aCharLen delegate is placed within the test class for simplicity
        private Action<string> aCharLen = str => { Console.WriteLine($"Length of {str} is {str.Length}"); };

    }


}