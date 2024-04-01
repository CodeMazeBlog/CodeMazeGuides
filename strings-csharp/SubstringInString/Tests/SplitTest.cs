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
                var expectedOutput = "Index 0: <Bring>\r\n" +
                                        "Index 1: <the>\r\n" +
                                        "Index 2: <bricks>\r\n" +
                                        "Index 3: <to>\r\n" +
                                        "Index 4: <the>\r\n" +
                                        "Index 5: <brown>\r\n" +
                                        "Index 6: <box>\r\n" +
                                        "Index 7: <of>\r\n" +
                                        "Index 8: <brooks.>\r\n";
                                      
                // Assert
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}
