namespace Tests
{
    public static class RandomizerControllerFactory
    {
        public static RandomizerController TestRandomizerController { get; }

        public static Mock<IRandomizerClient> RandomizerClient { get; }

        static  RandomizerControllerFactory()
        {
            //Initialize Mocks
            var _hubContext = new Mock<IHubContext<RandomizerHub, IRandomizerClient>>();

            var mockClient = new Mock<IHubCallerClients<IRandomizerClient>>();

            RandomizerClient = new Mock<IRandomizerClient>();

            //Mock Setup
            _hubContext.Setup(m => m.Clients).Returns(mockClient.Object);

            RandomizerClient.Setup(m => m.SendClientRandomEvenNumber(It.IsAny<int>()));

            mockClient.Setup(m => m.All).Returns(RandomizerClient.Object);

            //Initialize RandomizerController
            var timerManager = new TimerManager();

            TestRandomizerController = new(_hubContext.Object, timerManager);
        }
    }
}
