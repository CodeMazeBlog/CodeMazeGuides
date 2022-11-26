using StringInterpolationDemo;

namespace Tests
{
    public class EscapedStringsUnitTest
    {
        [Test]
        public void WhenSimpleEscapedCurlyBracesCalled_ReturnsInterpolatedStringWithCurlyBraces()
        {
            const string expected = "We show {curly braces} inserted in the string.";

            string actual = EscapedStrings.SimpleEscapedCurlyBraces();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1, "1 bottle of beer on the wall.")]
        [TestCase(2, "2 bottles of beer on the wall.")]
        [TestCase(99, "99 bottles of beer on the wall.")]
        public void WhenThisManyBottlesOfBeerOnTheWallCalled_ReturnsInterpolatedString(int bottles, string expected)
        {
            string actual = EscapedStrings.ThisManyBottlesOfBeerOnTheWall(bottles);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}