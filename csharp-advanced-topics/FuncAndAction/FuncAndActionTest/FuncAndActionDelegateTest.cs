using FuncAndAction;

namespace FuncAndActionTest
{
    public class FuncAndActionDelegateTest
    {
        [Fact]
        public void WhenUsingFunc_ReturnSquareOfNumber()
        {
            //Arrange
            FuncAndActionDelegates _sut = new FuncAndActionDelegates();
            //Act
            var result = _sut.FromFunc(2);
            //Assert
            Assert.Equal(4, result);
        }
        [Fact]
        public void WhenUsingAction_PrintTheMessageToTheScreen()
        {
            //Arrange
            FuncAndActionDelegates _sut = new FuncAndActionDelegates();
            string message = "Welcome To CodeMaze From The Action Delegate";
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(message);
            Console.SetIn(stringReader);
            //Act
            _sut.FromAction(message);
            //Assert
            var output = stringWriter.ToString();
            Assert.Equal($"{message}\r\n", output);
        }
    }
}