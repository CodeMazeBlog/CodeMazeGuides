namespace Test
{
    public class RandomizerControllerUnitTest
    {
        private readonly RandomizerController _randomizerController;

        public RandomizerControllerUnitTest()
        {
            var timerManager = new TimerManager();

            var hub = new Mock<IHubContext<RandomizerHub, IRandomizerClient>>();

            _randomizerController = new(hub.Object, timerManager);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnActionResult()
        {
            //Act
            var result = _randomizerController.SendRandomNumber();

            //Assert
            Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnInt()
        {
            //Act
            var result = _randomizerController.SendRandomNumber();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.IsType<int>(okResult.Value);
        }
    }
}
