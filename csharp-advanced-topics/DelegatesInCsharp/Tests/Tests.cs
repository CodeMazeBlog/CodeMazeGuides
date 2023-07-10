using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
	delegate string PrintMessage(string text);
	delegate T Print<T>(T param1);

	[TestClass]
	public class Tests
	{
		
		[TestMethod]
        public void Test_PrintSquare_WhenCalled_PrintsSquareOfEachNumber()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedSquares = new List<int> { 1, 4, 9, 16, 25 };
            List<int> actualSquares = new List<int>();

            Action<int> printSquare = (x) =>
            {
                int square = x * x;
                actualSquares.Add(square);
            };

            // Act
            numbers.ForEach(printSquare);

            // Assert
            CollectionAssert.AreEqual(expectedSquares, actualSquares);
        }
        [TestMethod]
        public void Test_GetEvenNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedEvenNumbers = new List<int> { 2, 4 };

            Func<int, bool> isEven = (x) => x % 2 == 0;

            // Act
            List<int> evenNumbers = numbers.Where(isEven).ToList();

            // Assert
            CollectionAssert.AreEqual(expectedEvenNumbers, evenNumbers);
        }
    }
}
