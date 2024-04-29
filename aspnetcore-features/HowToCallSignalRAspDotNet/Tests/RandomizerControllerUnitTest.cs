namespace Test
{
    public class RandomizerControllerUnitTest
    {
        [Fact]
        public async Task GivenSendRandomNumber_WhenCalled_ThenInvokeMethodOnClient()
        {
            //Act
            TestRandomizerController.SendRandomNumber();

            await Task.Delay(2000);//Delay to allow complete intialization of our Timer

            //Assert
            RandomizerClient.Verify(m => m.SendClientRandomEvenNumber(It.IsAny<int>()), Times.AtLeast(1));
        }

        [Fact]
        public void WhenSendRandomNumber_ThenVerifyResult()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            var okResult = (OkObjectResult)result.Result!;
            Assert.IsAssignableFrom<ActionResult<int>>(result);
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.IsType<int>(okResult.Value);
        }
    }
}
