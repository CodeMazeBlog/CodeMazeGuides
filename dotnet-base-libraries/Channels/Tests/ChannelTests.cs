using Moq;
using System.Collections.Generic;
using System.Threading.Channels;
using System.Threading.Tasks;
using Xunit;

namespace Tests;
public class ChannelTests
{
    private readonly Mock<ChannelWriter<string>> _channelWriter = new();
    private readonly Mock<ChannelReader<string>> _channelReader = new();
    private readonly Producer _producer;
    private readonly Consumer _consumer;

    public ChannelTests()
    {
        _producer = new Producer(_channelWriter.Object);
        _consumer = new Consumer(_channelReader.Object);
    }

    [Fact]
    public async Task GivenAChannelWriter_WhenProducingItems_ThenAllGetPublishedToChannel()
    {
        // Arrange
        _channelWriter.Setup(x => x.WriteAsync(It.IsAny<string>(), default))
            .Returns(new ValueTask());

        // Act
        await _producer.ProduceWorkAsync();

        // Assert
        _channelWriter.Verify(_ => _.WriteAsync(It.IsAny<string>(), default), Times.AtLeastOnce());
    }

    [Fact]
    public async Task GivenAChannelReader_WhenItemsToConsume_ThenReadsItemsFromChannel()
    {
        // Arrange
        _channelReader.Setup(x => x.ReadAllAsync(default))
            .Returns(GetItemsAsync());

        // Act
        await _consumer.ConsumeWorkAsync();

        // Assert
        _channelReader.Verify(_ => _.ReadAllAsync(default), Times.AtLeastOnce());
    } 

    private static async IAsyncEnumerable<string> GetItemsAsync()
    {
        yield return "Make a coffee";
        yield return "Read CodeMaze articles";
        yield return "Go for a run";
        yield return "Eat lunch";

        await Task.CompletedTask;
    }
}