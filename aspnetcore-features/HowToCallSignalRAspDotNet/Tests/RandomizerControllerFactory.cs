namespace Tests
{
    public static class RandomizerControllerFactory
    {
        public static RandomizerController TestRandomizerController { get; }
        public static RandomizerWithNonGenericHubController TestNonGenericRandomizerController { get; }
        public static Mock<IRandomizerClient> RandomizerClient { get; }
        public static Mock<IClientProxy> ClientProxy { get; }

        static  RandomizerControllerFactory()
        {
            //Initialize TestRandomControllerMocks
            var hubContext = new Mock<IHubContext<RandomizerHub, IRandomizerClient>>();

            var mockClient = new Mock<IHubCallerClients<IRandomizerClient>>();
            
            hubContext.Setup(m => m.Clients).Returns(mockClient.Object);

            RandomizerClient = new Mock<IRandomizerClient>();

            RandomizerClient.Setup(m => m.SendClientRandomEvenNumber(It.IsAny<int>()));

            mockClient.Setup(m => m.All).Returns(RandomizerClient.Object);            

            TestRandomizerController = new(hubContext.Object, new TimerManager());


            //Initialize TestNonGenericRandomizerController

            var nonGenericHubContext = new Mock<IHubContext<RandomizerHub>>();

            var nonGenericMockClient = new Mock<IHubClients>();

            ClientProxy = new Mock<IClientProxy>();

            ClientProxy.Setup(c => c.SendCoreAsync(It.IsAny<string>(), It.IsAny<object?[]>(), It.IsAny<CancellationToken>()));

            nonGenericHubContext.Setup(m => m.Clients).Returns(nonGenericMockClient.Object);

            nonGenericMockClient.Setup(m => m.All).Returns(ClientProxy.Object);

            TestNonGenericRandomizerController = new(nonGenericHubContext.Object, new TimerManager());
        }
    }
}
