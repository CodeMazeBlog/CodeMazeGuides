namespace Tests
{
    public class RandomizerWithNonGenericHubControllerTest
    {
        [Fact]
        public async Task GivenSendRandomNumber_WhenCalled_ThenInvokeMethodOnClient()
        {
            //Act
            TestNonGenericRandomizerController.SendRandomNumber();

            await Task.Delay(3000);//Delay to allow complete intialization of our Timer

            //Assert
            ClientProxy.Verify(m => m.SendCoreAsync(It.IsAny<string>(), It.IsAny<object?[]>(), It.IsAny<CancellationToken>()), Times.AtLeast(1));
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnActionResult()
        {
            //Act
            var result = TestNonGenericRandomizerController.SendRandomNumber();

            //Assert
            Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnOkObject()
        {
            //Act
            var result = TestNonGenericRandomizerController.SendRandomNumber();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnInt()
        {
            //Act
            var result = TestNonGenericRandomizerController.SendRandomNumber();

            //Assert
            var okResult = (OkObjectResult)result.Result!;

            Assert.IsType<int>(okResult.Value);
        }
    }
}
