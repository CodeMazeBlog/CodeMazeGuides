using System.Reflection;

namespace Tests
{
    public class AdvancedDebuggingInCSharpUnitTests
    {
        [Fact]
        public void GivenPrintPartMethod_WhenArgumentsAreCorrect_ThenCorrectSubstringIsReturned()
        {
            // Arrange
            string word = "beautiful";
            int length = 4;

            TypeInfo program = typeof(Program).GetTypeInfo();
            var printPartMethod = program.DeclaredMethods.Single(m => m.Name.Contains("PrintPart"));

            // Act
            string result = printPartMethod.Invoke(null, new object[] { word, length }).ToString();

            // Assert
            Assert.Equal("beau", result); 
        }

        [Fact]
        public void GivenMainMethod_WhenProgramIsRun_ThenPrintPartMethodIsCalledForEachString()
        {
            // Arrange
            StringWriter writer = new StringWriter();
            Console.SetOut(writer);
                        
            TypeInfo program = typeof(Program).GetTypeInfo();
            var mainMethod = program.DeclaredMethods.Single(m => m.Name == "<Main>$");

            // Act
            mainMethod.Invoke(null, new object[] { new string[2] { "", "" } });
            var wordCount = writer.ToString().Count(x => x == '\n');

            // Assert
            Assert.Equal(6, wordCount);
        }
    }
}