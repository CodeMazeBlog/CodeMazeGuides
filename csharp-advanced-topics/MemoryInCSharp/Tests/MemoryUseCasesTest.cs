using App;
using Moq;

namespace Tests;

public class MemoryUseCasesTest
{
    private readonly Mock<TextWriter> _mockTextWriter;

    public MemoryUseCasesTest()
    {
        _mockTextWriter = new Mock<TextWriter>();
        Console.SetOut(_mockTextWriter.Object);
    }

    [Fact]
    public void WhenWorksWithBothStackAndHeapCalled_ThenShouldWriteToConsole()
    {
        MemoryUseCases.WorksWithBothStackAndHeap();
        
        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
    }

    [Fact]
    public void WhenStringAsMemoryExtensionMethodCalled_ThenShouldWriteToConsole()
    {
        MemoryUseCases.StringAsMemoryExtensionMethod();
        
        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<string>()), Times.AtLeastOnce);
    }

    [Fact]
    public void WhenUseMemoryOwnerCalled_ThenShouldWriteToConsole()
    {
        MemoryUseCases.UseMemoryOwner();

        _mockTextWriter.Verify(tw => tw.WriteLine(It.IsAny<int>()), Times.AtLeastOnce);
    }

    [Fact]
    public async Task WhenProcessFileAsyncCalled_ThenShouldWriteToConsole()
    {
        var filePath = "test.txt";
        var fileContent = "Hello World";
        await File.WriteAllTextAsync(filePath, fileContent);
        await MemoryUseCases.ProcessFileAsync(filePath);

        _mockTextWriter.Verify(tw => tw.Write(It.IsAny<char>()), Times.AtLeastOnce);
        File.Delete(filePath);
    }
}