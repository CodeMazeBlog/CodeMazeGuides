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
                var expectedOutput = "substring found at index 51: code" + Environment.NewLine +
                                 "substring found at index 75: code" + Environment.NewLine +
                                 "substring found at index 91: code" + Environment.NewLine +
                                 "substring found at index 124: code" + Environment.NewLine;

                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
