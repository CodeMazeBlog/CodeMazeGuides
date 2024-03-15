using log4net;
using Moq;
using StructuredLoggingUsingLog4Net.Controllers;

namespace Tests
{
    public class LogTestControllerTests
    {
        [Fact]
        public void Get_WhenCalled_InvokesLog4netMethods()
        {
            //arrange
            Mock<ILog> mock = new();
            LogTestController controller = new(mock.Object);

            //act
            controller.Get();

            //assert
            mock.Verify(m => m.Info(It.IsAny<object>()), Times.AtLeastOnce);
            mock.Verify(m => m.Error(It.IsAny<object>()), Times.AtLeastOnce);            
        }
    }
}
