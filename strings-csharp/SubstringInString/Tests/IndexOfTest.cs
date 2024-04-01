namespace Tests
{
    [TestFixture]
    public class IndexOfTest
    {
        [Test]
        public void Given_InputString_When_Indexofmethod_Called_Then_ExpectedOutput()
        {
            var input = "Taking a walk in spring is great";
            var substring = "a";
            var expectedOccurrences = new List<int> { 1, 7, 10, 30 }; // Positions of 'a'

            // Redirect Console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                IndexOfMethod.Indexofmethod();
                
                // Assert
                var actualOutput = sw.ToString();
                foreach (var occurrence in expectedOccurrences)
                {
                    var expectedOutput = string.Format("Found '{0}' in '{1}' at position {2}", substring, input, occurrence);
                    Assert.That(actualOutput, Contains.Substring(expectedOutput), $"Expected '{expectedOutput}' not found in actual output.");
                }
            }
        }
    }
}