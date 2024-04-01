namespace Tests
{
    [TestFixture]
    public class IndexOfTest
    {
        [Test]
        public void Given_InputString_When_Indexofmethod_Called_Then_ExpectedOutput()
        {
            // Arrange
            var input = "Taking a walk in spring is great";
            var substring = "a";

            // Redirect Console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                IndexOfMethod.Indexofmethod();
                var expectedOutput = string.Format("Found '{0}' in '{1}' at position {2}\r\n", substring, input, 1);

                // Assert
                Assert.That(sw.ToString(), Contains.Substring(expectedOutput));
            }
        }
    }
}