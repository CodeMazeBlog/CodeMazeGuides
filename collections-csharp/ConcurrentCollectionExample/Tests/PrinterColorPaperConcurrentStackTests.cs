using System;
using ExampleApp.ConcurrentStackExamples;

namespace Tests;

public class PrinterColorPaperConcurrentStackTests
{
    [Fact]
    public async Task GivenColors_WhenAddIsInvokedConcurrently_ThenColorsAreAdded()
    {
        var papers = new PrinterColorPaperConcurrentStack();
        var task1 = Task.Run(() => papers.Add("white"));
        var task2 = Task.Run(() => papers.Add("green"));
        var task3 = Task.Run(() => papers.Add("yellow"));

        await Task.WhenAll(task1, task2, task3);

        Assert.Equal(3, papers.Count());
    }

    [Fact]
    public void GivenFileName_WhenTryRemoveIsInvoked_ThenFileIsRemovedAndReturnsTrue()
    {
        var color = "white";
        var papers = new PrinterColorPaperConcurrentStack();
        papers.Add(color);
        var result = papers.TryUse(out string? removedColor);

        Assert.True(result);
        Assert.Equal(color, removedColor);
    }

    [Fact]
    public void GivenFileName_WhenTryGetIsInvoked_ThenFileIsRetrivedAndReturnsTrue()
    {
        var color = "white";
        var papers = new PrinterColorPaperConcurrentStack();
        papers.Add(color);
        var result = papers.TryGetTop(out string? retrievedColor);

        Assert.True(result);
        Assert.Equal(1, papers.Count());
        Assert.Equal(color, retrievedColor);
    }
}

