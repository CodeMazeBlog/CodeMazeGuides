namespace CodeMaze.ActionAndFunc.Tests
{
    /// <summary>
    /// This UNitTest is used to test the 3 delegate functions defined in Main project
    /// </summary>
    public class MainTests
    {
        /// <summary>
        /// Expected: Console print 'Hello A B' 
        /// </summary>
        [Fact]
        public void Main_CallsFunctionA()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Action<string, string> expectedHandle = Program.FunctionA;

                // Act
                expectedHandle("A", "B");
                var actual = sw.ToString().Trim();

                // Assert
                Assert.Equal("Hello A B", actual);
            }
        }

        /// <summary>
        /// Expected: Console print 'Hello A B' & return TRUE 
        /// </summary>
        [Fact]
        public void Main_CallsFunctionB()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Func<string, string, bool> expectedHandle = Program.FunctionB;

                // Act
                var result = expectedHandle("A", "B");
                var actual = sw.ToString().Trim();

                // Assert
                Assert.True(result);
                Assert.Equal("Hello A B", actual);
            }
        }

        /// <summary>
        /// Expected: Console print 'Hello CodeMaze Blog' 
        /// </summary>
        [Fact]
        public void FunctionA_Test()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var expectedTextA = "CodeMaze";
                var expectedTextB = "Blog";

                // Act
                Program.FunctionA(expectedTextA, expectedTextB);
                string result = sw.ToString().Trim();

                // Assert
                Assert.Equal($"Hello {expectedTextA} {expectedTextB}", result);
            }
        }

        /// <summary>
        /// Expected: Console print 'Hello CodeMaze Blog' 
        /// </summary>
        [Fact]
        public void FunctionB_Test()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var expectedTextA = "CodeMaze";
                var expectedTextB = "Blog";

                // Act
                var result = Program.FunctionB(expectedTextA, expectedTextB);
                string Consoleresult = sw.ToString().Trim();

                // Assert
                Assert.Equal($"Hello {expectedTextA} {expectedTextB}", Consoleresult);
                Assert.True(result);
            }
        }

        /// <summary>
        /// Expected: Console print 'Hello CodeMaze Blog' 
        /// </summary>
        [Fact]
        public void FunctionC_Test()
        {
            // Arrange
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                Program.FunctionC((string textA, string textB) =>
                {
                    Console.WriteLine("Anonymous lambda function");
                });
                string result = sw.ToString().Trim();

                // Assert
                Assert.Equal("Anonymous lambda function", result);
            }
        }
    }

}