using CodeMazeWorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CodeMazeWorkerServiceTests
    {
        [Fact]
        public async void WorkerService_WhenStarted_ThenLogsInformation()
        {
            //Arrange
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IHostedService, Worker>();
            Mock<ILogger<Worker>> mockLogger = new();
            services.AddSingleton(mockLogger.Object);
            var workerService = services.BuildServiceProvider().GetService<IHostedService>();

            //Act
            await workerService.StartAsync(CancellationToken.None);
            await Task.Delay(1000);
            await workerService.StopAsync(CancellationToken.None);
            
            //Assert
            mockLogger.Verify(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()));
        }
    }
}