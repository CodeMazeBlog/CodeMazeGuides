using NUnit.Framework;
using System.Runtime.InteropServices;

namespace NUnitProject.Tests
{

    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Ignore("example how to ignore tests")]
        [Test]
        public void Ignored_Should_NotRun()
        {
            // Assert that 1 equals 2 always gives failed test 
            Assert.AreEqual(1, 2);
        }

        // fails intentionaly to show the work of max time attribute
        [MaxTime(1000)]
        [Test]
        public async Task Should_CompleteInTime()
        {
            await Task.Delay(1100);

            // Assert
            Assert.IsTrue(true);
        }

        [Author("Andrew")]
        [Test]
        public void Should_AccessAuthor()
        {
            var expected = "Andrew";
            // Act
            var author = (string)TestContext.CurrentContext.Test.Properties.Get("Author");
            // Assert
            Assert.AreEqual(author, expected);
        }

        [Test]
        [Description("this is simple test case")]
        public void Should_HaveDescription()
        {
            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        [Category("simple_tests")]
        public void Should_HaveCategory()
        {
            // Assert
            Assert.IsTrue(true);
        }

        [Test]

        public void Divide_ShouldReturnDivisionOfTwoNumbers()
        {
            // Arrange
            var a = 300;
            var b = 100;

            var expected = 3;

            // Act
            var actual = _calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(300, 100, 3)]
        [TestCase(400, 200, 2)]
        [Category("simple_tests")]
        public void Divide_ShouldReturnDivisionOfTwoNumbers(int a, int b, double expected)
        {
            // Act
            var actual = _calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(SourceProvider))]
        [Category("simple_tests")]
        public void Divide_ShouldReturnDivisionOfTwoNumbersProvidedBySource(int a, int b, double expected)
        {
            // Act
            var actual = _calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }


        public static IEnumerable<int[]> SourceProvider()
        {
            yield return new int[] { 300, 100, 3 };
            yield return new int[] { 400, 200, 2 };
        }
    }
}