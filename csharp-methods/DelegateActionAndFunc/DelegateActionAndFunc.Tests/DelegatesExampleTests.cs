namespace DelegateActionAndFunc.Tests
{
    public class DelegatesExampleTests
    {

        [Fact]
        public void TestActionMethod()
        {
            // Arrange
            var delegateExample = new DelegatesExample();
            string expectedLog = "Hello world";
            using var sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            delegateExample.showMessage("Hello world");

            // Assert
            string resultLog = sw.ToString().Trim();
            Assert.Equal(expectedLog, resultLog);
        }

        [Fact]
        public void TestFuncMethod()
        {
            // Arrange
            var delegateExample = new DelegatesExample();
            int expectedResult = 10;

            // Act
            int result = delegateExample.Add(2, 8);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}