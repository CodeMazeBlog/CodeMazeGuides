using System.Globalization;
using StringInterpolationDemo;

namespace Tests
{
    public class BasicStringsUnitTest
    {
        [Test]
        public void WhenConstantStringConstantUsed_ReturnsHelloWorld()
        {
            const string expected = "Hello world!";

            string actual = BasicStrings.ConstantString;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenSimpleStringsCalled_ShowsInterpolatedMessage()
        {
            const string expected = "Hey Joe, where you goin' with that bun in your hand?";

            string actual = BasicStrings.SimpleString("Joe", "bun");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenThisManyBottlesOfBeerOnTheWallCalled_ReturnsMessageInterpolatedWithNumber([Values(99, 98, 97)] int numberOfBottles)
        {
            string expected = string.Format("{0} bottles of beer on the wall, {0} bottles of beer.", numberOfBottles);

            string actual = BasicStrings.ThisManyBottlesOfBeerOnTheWall(numberOfBottles);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [SetCulture("en-US")]
        [TestCase(150, false, "150.00   ")]
        [TestCase(150, true, "   150.00")]
        public void WhenDisplayTableCellCalled_ReturnsPaddedAndAlignedString(int data, bool alignRight, string expected)
        {
            string actual = BasicStrings.DisplayTableCell(data, alignRight);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, "You took 1st place.")]
        [TestCase(2, "You took 2nd place.")]
        [TestCase(3, "You took 3rd place.")]
        [TestCase(4, "You took 4th place.")]
        public void WhenNewLinesInExpressionCalled_ReturnsInterpolatedString(int place, string expected)
        {
            string actual = BasicStrings.NewLinesInExpression(place);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}