namespace Test
{
    public class RandomizerControllerUnitTest
    {       

        [Fact]
        public void WhenSendRandomNumber_ThenReturnActionResult()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnInt()
        {
            //Act
            var result = TestRandomizerController.SendRandomNumber();

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.IsType<int>(okResult.Value);
        }
    }
}
