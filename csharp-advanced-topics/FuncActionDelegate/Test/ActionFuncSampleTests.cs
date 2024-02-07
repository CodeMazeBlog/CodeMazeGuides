using FuncActionDelegate;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;

namespace Test
{
    [TestFixture]
    public class ActionFuncSampleTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Greeting_ShouldPrintCorrectMessages()
        {
            // Arrange
            var names = new List<string> { "Alice", "Bob", "Charlie" };
            var actionSample = new ActionSample();
            var output = new StringWriter();
            Console.SetOut(output);

            // Act
            actionSample.Greeting(names);

            // Assert
            var outputString = output.ToString();
            StringAssert.Contains("Hello, Alice!", outputString);
            StringAssert.Contains("Hello, Bob!", outputString);
            StringAssert.Contains("Hello, Charlie!", outputString);

            // Cleanup
            Console.SetOut(Console.Out);
        }

        [Test]
        public void FilterAndSum_ShouldReturnSumOfEvenNumbers()
        {
            // Arrange
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var funcSample = new FuncSample();

            // Act
            int result = funcSample.FilterAndSum(numbers);

            // Assert
            Assert.That(result, Is.EqualTo(30)); // The sum of even numbers (2 + 4 + 6 + 8 + 10) is 30.
        }
    }
}