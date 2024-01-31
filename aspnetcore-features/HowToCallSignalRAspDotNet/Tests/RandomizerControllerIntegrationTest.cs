namespace Test
{
    public class RandomizerControllerIntegrationTest
    {
        private RandomizerController _randomizerController;

        private readonly Mock<IRandomizerClient> _randomizerClient;

        public RandomizerControllerIntegrationTest()
        {
            //Initialize Mocks
            var _hubContext = new Mock<IHubContext<RandomizerHub, IRandomizerClient>>();

            var mockClient = new Mock<IHubCallerClients<IRandomizerClient>>();

            _randomizerClient = new Mock<IRandomizerClient>();

            //Mock Setup
            _hubContext.Setup(m => m.Clients).Returns(mockClient.Object);

            _randomizerClient.Setup(m => m.SendClientRandomEvenNumber(It.IsAny<int>()));

            mockClient.Setup(m => m.All).Returns(_randomizerClient.Object);

            //Initialize RandomizerController
            var timerManager = new TimerManager();

            _randomizerController = new(_hubContext.Object, timerManager);
        }

        [Fact]
        public async Task GivenSendRandomNumber_WhenCalled_ThenInvokeMethodOnClient()
        {
            //Act
            _randomizerController.SendRandomNumber();

            await Task.Delay(2000);//Delay to allow complete intialization of our Timer

            //Assert
            _randomizerClient.Verify(m => m.SendClientRandomEvenNumber(It.IsAny<int>()), Times.AtLeast(1));
        }
    }
}
