using DelegateExamples;

namespace DelegatesExamplesTests
{
    public class DelegateExamplesTests
    {
        [Fact]
        public void GivenActionDelegate_WhenDisplayMessageCalled_ThenDisplayHelloWorld()
        {
            // Arrange
            using StringWriter sw = new StringWriter();
            Console.SetOut(sw);

            // Act
            DelegateExamplesManager.ActionExample();

            // Assert
            string expected = "Hello, World!" + Environment.NewLine;
            Assert.Equal(expected, sw.ToString());
        }

        [Fact]
        public void GivenFuncDelegate_WhenMultiplyNumbersCalled_ThenReturnProduct()
        {
            // Act
            int result = DelegateExamplesManager.FuncExample();

            // Assert
            Assert.Equal(15, result);
        }
    }
}