using log4net;
using Moq;
using Log4netAppenders.Controllers;

namespace Tests
{
    public class LogTestControllerTests
    {
        [Fact]
        public void GivenLog4NetConfigured_WhenGetMethodIsCalled_ThenLog4netMethodsAreInvoked()
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
