using System.Net.WebSockets;
using System.Text;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public async Task WhenConnectedToWebSocket_ThenPrintTimeToConsole()
        {
            // Arrange
            var serverUri = new Uri("ws://localhost:5289/ws");
            var ws = new ClientWebSocket();
            var cancellationToken = CancellationToken.None;

            // Act: Connect to the WebSocket server
            await ws.ConnectAsync(serverUri, cancellationToken);
            Console.WriteLine("Connected!");

            var receiveTask = Task.Run(async () =>
            {
                var buffer = new byte[1024];
                while (true)
                {
                    var result = await ws.ReceiveAsync(new ArraySegment<byte>(buffer), cancellationToken);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        break;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    Console.WriteLine("Received: " + message);
                }
            });

            await Task.Delay(2000);
            Assert.False(receiveTask.IsFaulted);
            Assert.False(receiveTask.IsCanceled);

            ws.Dispose();
        }
    }
}
