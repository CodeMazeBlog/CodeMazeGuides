namespace Tests
{
    [TestFixture]
    public class RegexMethodTests
    {
        [Test]
        public void Given_InputString_When_Regexmethod_Called_Then_ExpectedOutput()
        {
            // Redirect Console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                RegexMethod.Regexmethod();
                var expectedOutput = "substring found at index 51: code\r\n" +
                                        "substring found at index 75: code\r\n" +
                                        "substring found at index 91: code\r\n" +
                                        "substring found at index 124: code\r\n";

                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
