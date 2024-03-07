using App;
using Moq;

namespace Tests;

public class MemoryUseCasesTest
{
    private readonly MemoryUseCases _memoryUseCases;
    private readonly Mock<TextWriter> _mockTextWriter;

    public MemoryUseCasesTest()
    {
        _mockTextWriter = new Mock<TextWriter>();
        Console.SetOut(_mockTextWriter.Object);
        _memoryUseCases = new MemoryUseCases();
    }

    [Fact]
    public void When_WorksWithBothStackAndHeap_Called_Then_ShouldWriteToConsole()
    {
        _memoryUseCases.WorksWithBothStackAndHeap();
        
        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
    }

    [Fact]
    public void When_StringAsMemoryExtensionMethod_Called_Then_ShouldWriteToConsole()
    {
        _memoryUseCases.StringAsMemoryExtensionMethod();
        
        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
    }

    [Fact]
    public void When_UseMemoryOwner_Called_Then_ShouldWriteToConsole()
    {
        _memoryUseCases.UseMemoryOwner();

        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<int>()), Times.AtLeastOnce);
    }

    [Fact]
    public async Task When_ProcessFileAsync_Called_Then_ShouldWriteToConsole()
    {
        var filePath = "test.txt";
        var fileContent = "Hello World";
        await File.WriteAllTextAsync(filePath, fileContent);
        await _memoryUseCases.ProcessFileAsync(filePath);

        _mockTextWriter.Verify(tw => tw.Write(It.IsAny<char>()), Times.AtLeastOnce);
        File.Delete(filePath);
    }
}