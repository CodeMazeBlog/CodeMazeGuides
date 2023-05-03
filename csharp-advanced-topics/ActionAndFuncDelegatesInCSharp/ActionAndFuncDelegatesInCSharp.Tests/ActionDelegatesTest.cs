namespace ActionAndFuncDelegatesInCSharp.Tests;

public class ActionDelegatesTest: IDisposable
    {
        private readonly StringWriter _stringWriter;

        public ActionDelegatesTest()
        {
            _stringWriter = new StringWriter();
            Console.SetOut(_stringWriter);
        }

        public void Dispose()
        {
            _stringWriter.Dispose();
        }

        [Fact]
        public void When_AddNumbersCalled_Then_DisplaySum()
        {
            // Arrange
            Action<int, int> addNumbers = ActionDelegates.AddNumbers;

            // Act
            addNumbers(1,10);

            // Assert
            string expectedResult = "The sum is: 11";
            string actualResult = _stringWriter.ToString().TrimEnd();
            Assert.Equal(expectedResult, actualResult);
        }
}