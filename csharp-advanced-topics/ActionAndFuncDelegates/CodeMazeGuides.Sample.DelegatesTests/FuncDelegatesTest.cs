using CodeMazeGuides.Sample.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMazeGuides.Sample.DelegatesTests
{
	public class FuncDelegatesTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Given_PositiveNumber_When_CalculatingCube_Then_ReturnsCorrectResult()
		{
			// Given
			int input = 3;
			int expected = 27;

			// When
			int result = FuncDelegates.Cube(input);

			// Then
			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Given_NegativeNumber_When_CalculatingCube_Then_ReturnsCorrectResult()
		{
			// Given
			int input = -2;
			int expected = -8;

			// When
			int result = FuncDelegates.Cube(input);

			// Then
			Assert.AreEqual(expected, result);
		}

		[Test]
		public void Given_Zero_When_CalculatingCube_Then_ReturnsZero()
		{
			// Given
			int input = 0;
			int expected = 0;

			// When
			int result = FuncDelegates.Cube(input);

			// Then
			Assert.AreEqual(expected, result);
		}


		[Test]
		public void Given_RandomStringGenerator_When_ComputeRandomIsInvoked_Then_ReturnsStringWithTenDigits()
		{
			// Given
			var randomStringGenerator = FuncDelegates.ComputeRandom;

			// When
			var result = randomStringGenerator();

			// Then
			Assert.IsNotNull(result, "The generated string should not be null");
			Assert.AreEqual(10, result.Length, "The generated string length should be 10");

			// Additional validation that the string contains only digits
			Assert.IsTrue(IsStringNumeric(result), "The generated string should contain only digits");
		}

		private bool IsStringNumeric(string str)
		{
			foreach (char c in str)
			{
				if (!char.IsDigit(c))
				{
					return false;
				}
			}
			return true;
		}

		[Test]
		public void Given_StudentNameAndAge_When_DisplayStdInfoInvoked_Then_ReturnsFormattedInfo()
		{
			// Given
			string studentName = "Michelle Ezra";
			int studentAge = 20;
			string expected = "Name: Michelle Ezra, Age: 20";

			// When
			var result = FuncDelegates.DisplayStdInfo(studentName, studentAge);

			// Then
			Assert.AreEqual(expected, result);
		}
	}
}
