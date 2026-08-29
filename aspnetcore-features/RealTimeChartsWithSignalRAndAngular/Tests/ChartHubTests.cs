using Microsoft.AspNetCore.SignalR;
using Moq;
using RealTimeCharts.Server.HubConfig;
using RealTimeCharts.Server.Models;

namespace Tests
{
    public class ChartHubTests
    {
        private const string ConnectionId = "test-connection-id";

        private readonly Mock<IHubCallerClients> _clients = new();
        private readonly Mock<IClientProxy> _allProxy = new();
        private readonly Mock<ISingleClientProxy> _singleProxy = new();
        private readonly Mock<IClientProxy> _userProxy = new();
        private readonly Mock<IClientProxy> _groupProxy = new();
        private readonly Mock<IGroupManager> _groups = new();
        private readonly ChartHub _hub;

        public ChartHubTests()
        {
            _clients.Setup(c => c.All).Returns(_allProxy.Object);
            _clients.Setup(c => c.Client(It.IsAny<string>())).Returns(_singleProxy.Object);
            _clients.Setup(c => c.User(It.IsAny<string>())).Returns(_userProxy.Object);
            _clients.Setup(c => c.Group(It.IsAny<string>())).Returns(_groupProxy.Object);

            var context = new Mock<HubCallerContext>();
            context.Setup(c => c.ConnectionId).Returns(ConnectionId);

            _hub = new ChartHub
            {
                Clients = _clients.Object,
                Groups = _groups.Object,
                Context = context.Object
            };
        }

        [Fact]
        public async Task WhenBroadcastChartDataIsCalled_ThenAllClientsReceiveTheData()
        {
            var data = new List<ChartModel> { new() { Label = "Data1" } };

            await _hub.BroadcastChartData(data);

            _allProxy.Verify(p => p.SendCoreAsync(
                "broadcastchartdata",
                It.Is<object?[]>(a => a.Length == 1 && ReferenceEquals(a[0], data)),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WhenBroadcastChartDataToClientIsCalled_ThenOnlyThatConnectionReceivesTheData()
        {
            var data = new List<ChartModel> { new() { Label = "Data1" } };

            await _hub.BroadcastChartDataToClient(data, ConnectionId);

            _clients.Verify(c => c.Client(ConnectionId), Times.Once);
            _singleProxy.Verify(p => p.SendCoreAsync(
                "broadcastchartdata",
                It.Is<object?[]>(a => a.Length == 1 && ReferenceEquals(a[0], data)),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public void WhenGetConnectionIdIsCalled_ThenTheCallerConnectionIdIsReturned()
        {
            Assert.Equal(ConnectionId, _hub.GetConnectionId());
        }

        [Fact]
        public async Task WhenBroadcastToConnectionIsCalled_ThenTheNamedConnectionIsTargeted()
        {
            await _hub.BroadcastToConnection("payload", ConnectionId);

            _clients.Verify(c => c.Client(ConnectionId), Times.Once);
            _singleProxy.Verify(p => p.SendCoreAsync(
                "broadcasttoclient",
                It.Is<object?[]>(a => a.Length == 1 && (string)a[0]! == "payload"),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WhenBroadcastToUserIsCalled_ThenEveryConnectionOfThatUserIsTargeted()
        {
            await _hub.BroadcastToUser("payload", "user-1");

            _clients.Verify(c => c.User("user-1"), Times.Once);
            _userProxy.Verify(p => p.SendCoreAsync(
                "broadcasttouser",
                It.Is<object?[]>(a => a.Length == 1 && (string)a[0]! == "payload"),
                It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WhenAddToGroupAndRemoveFromGroupAreCalled_ThenTheCallerConnectionIsMoved()
        {
            await _hub.AddToGroup("room-1");
            await _hub.RemoveFromGroup("room-1");

            _groups.Verify(g => g.AddToGroupAsync(ConnectionId, "room-1", It.IsAny<CancellationToken>()), Times.Once);
            _groups.Verify(g => g.RemoveFromGroupAsync(ConnectionId, "room-1", It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task WhenBroadcastToGroupIsCalled_ThenTheGroupReceivesTheJoinMessage()
        {
            await _hub.BroadcastToGroup("room-1");

            _clients.Verify(c => c.Group("room-1"), Times.Once);
            _groupProxy.Verify(p => p.SendCoreAsync(
                "broadcasttogroup",
                It.Is<object?[]>(a => a.Length == 1
                    && (string)a[0]! == $"{ConnectionId} has joined the group room-1."),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
