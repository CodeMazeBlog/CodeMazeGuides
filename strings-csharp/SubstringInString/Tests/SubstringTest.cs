namespace Tests
{
    [TestFixture]
    public class SubstringMethodTests
    {
        [Test]
        public void Given_UserInput_When_Substringmethod_Called_Then_ExpectedOutput()
        {
            var expectedOutput = $"Found 'sub' in 'This is a substring method for searching for substrings in a string' at position 10{Environment.NewLine}" +
                         $"Found 'sub' in 'This is a substring method for searching for substrings in a string' at position 45{Environment.NewLine}" +
                         $"Total occurrences found: 2{Environment.NewLine}";

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                SubstringMethod.Substringmethod();

                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
