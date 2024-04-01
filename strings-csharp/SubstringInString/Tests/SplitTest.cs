namespace Tests
{
    [TestFixture]
    public class SplitMethodTests
    {
        [Test]
        public void Given_Text_When_Splitmethod_Called_Then_ExpectedOutput()
        {
            // Redirect Console output to capture it
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                SplitMethod.Splitmethod();
                var expectedOutput = "Index 0: <Bring>" + Environment.NewLine +
                                "Index 1: <the>" + Environment.NewLine +
                                "Index 2: <bricks>" + Environment.NewLine +
                                "Index 3: <to>" + Environment.NewLine +
                                "Index 4: <the>" + Environment.NewLine +
                                "Index 5: <brown>" + Environment.NewLine +
                                "Index 6: <box>" + Environment.NewLine +
                                "Index 7: <of>" + Environment.NewLine +
                                "Index 8: <brooks.>" + Environment.NewLine;
                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
