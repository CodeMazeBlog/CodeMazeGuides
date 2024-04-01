namespace Tests
{
    [TestFixture]
    public class SubstringMethodTests
    {
        [Test]
        public void Given_UserInput_When_Substringmethod_Called_Then_ExpectedOutput()
        {
            var input = "This is a substring method for searching for substrings in a string";
            var substring = "sub";
            var expectedOutput = $"Found 'sub' in 'This is a substring method for searching for substrings in a string' at position 10\r\n" +
                     $"Found 'sub' in 'This is a substring method for searching for substrings in a string' at position 45\r\n" +
                     $"Total occurrences found: 2\r\n";


            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                SubstringMethod.Substringmethod();

                // Assert
                Assert.AreEqual(expectedOutput, sw.ToString());
            }
        }
    }
}
