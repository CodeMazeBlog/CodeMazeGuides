namespace Test
{
    public class RandomizerControllerUnitTest
    {
        [Fact]
        public async Task GivenSendRandomNumber_WhenCalled_ThenInvokeMethodOnClient()
        {
            //Act
            TestRandomizerController.SendRandomNumber();

            await Task.Delay(4000);//Delay to allow complete intialization of our Timer

            //Assert
            RandomizerClient.Verify(m => m.SendClientRandomEvenNumber(It.IsAny<int>()), Times.AtLeast(1));
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnActionResult()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnOkObject()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnInt()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            var okResult = (OkObjectResult)result.Result!;

            Assert.IsType<int>(okResult.Value);
        }
    }
}
