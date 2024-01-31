namespace Test
{
    public class RandomizerControllerIntegrationTest
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
    }
}
