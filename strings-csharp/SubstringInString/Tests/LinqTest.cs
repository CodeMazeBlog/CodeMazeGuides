namespace Tests
{
    [TestFixture]
    public class LinqMethodTests
    {
        [Test]
        public void Given_InputString_When_Linqmethod_Called_Then_ExpectedOutput()
        {
            // Arrange
            var substring = "b";

            // Redirect Console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                LinqMethod.Linqmethod();
                var expectedOutput = $"Found '{substring}' at index 4\r\n"
                                      + $"Found '{substring}' at index 8\r\n"
                                      + $"Found '{substring}' at index 14\r\n"
                                      + $"Found '{substring}' at index 24\r\n";

                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
