using NUnit.Framework;

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
        public void WhenIgnored_ThenNotRun()
        {
            // Assert that 1 equals 2 always gives failed test 
            Assert.AreEqual(1, 2);
        }

        // fails intentionaly to show the work of max time attribute
        [MaxTime(1000)]
        [Test, Ignore("Ignored in order to prevent failed build")]
        public async Task WhenTakesMoreTime_ThenItFails()
        {
            await Task.Delay(1100);

            // Assert
            Assert.IsTrue(true);
        }

        [Author("Andrew")]
        [Test]
        public void WhenHasAuthor_ThenCanAccessItInCode()
        {
            var expected = "Andrew";
            // Act
            var author = (string)TestContext.CurrentContext.Test.Properties.Get("Author");
            // Assert
            Assert.AreEqual(author, expected);
        }

        [Test]
        [Description("this is simple test case")]
        public void WhenHaveDescription_ThenItsEasierToGetWhatItTests()
        {
            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        [Category("simple_tests")]
        public void WhenHaveCategory_ThenItCanBeInvokedWithCategoryFilder()
        {
            // Assert
            Assert.IsTrue(true);
        }

        [Test]

        public void WhenDivideTwoNumbers_ThenReturnDivisionOfTwoNumbers()
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
        public void WhenDivideTwoNumbers_ThenReturnDivisionOfTwoNumbers(int a, int b, double expected)
        {
            // Act
            var actual = _calculator.Divide(a, b);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(SourceProvider))]
        [Category("simple_tests")]
        public void WhenDivideTwoNumbers_ThenReturnDivisionOfTwoNumbersProvidedBySource(int a, int b, double expected)
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