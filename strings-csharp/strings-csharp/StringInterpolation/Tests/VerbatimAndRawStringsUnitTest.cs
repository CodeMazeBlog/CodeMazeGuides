using StringInterpolationDemo;

namespace Tests
{
    public class VerbatimAndRawStringsUnitTest
    {
        [Test]
        public void WhenSimpleVerbatimStringCalled_ReturnsInterpolatedVerbatimString()
        {
            const string expected = @"C:\images\profilePhoto.jpg";

            string actual = VerbatimAndRawStrings.SimpleVerbatimString("profilePhoto.jpg");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenAnotherVerbatimStringCalled_ReturnsInterpolatedVerbatimString()
        {
            const string expected = @"C:\images\profilePhoto.jpg";

            string actual = VerbatimAndRawStrings.AnotherVerbatimString("profilePhoto.jpg");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenSimpleRawStringCalled_ReturnsInterpolatedRawString()
        {
            const string expected = "In raw string we can use \" and line break without escaping.";

            string actual = VerbatimAndRawStrings.SimpleRawString();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void WhenEscapedRawStringCalled_ReturnsInterpolatedRawString()
        {
            const string expected = "In raw string we use the same number of {} as $ that prefix the raw string. We {can} also enclose expression.";

            string actual = VerbatimAndRawStrings.EscapedRawString();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}