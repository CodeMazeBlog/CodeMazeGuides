using Bunit;
using CopyToClipboardBlazor;
using CopyToClipboardBlazor.Pages;
using Microsoft.JSInterop;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System;

namespace Tests;
public class CopyToClipboardTests : TestContext
{
    private IClipboardService _clipboardService;
    private Mock<IClipboardService> _clipboardServiceMock;
    private Mock<IJSRuntime> _jsRuntimeMock;

    public CopyToClipboardTests()
    {
        _jsRuntimeMock = new Mock<IJSRuntime>();
        _clipboardService = new ClipboardService(_jsRuntimeMock.Object);

        _clipboardServiceMock = new Mock<IClipboardService>();
    }

    [Fact]
    public void GivenClipboardService_WhenProvidingTextToCopy_ThenClipboardWriteTextIsCalled()
    {
        // Arrange
        const string clipboardWriteTextFunction = "navigator.clipboard.writeText";
        const string textToCopy = "text";
        _jsRuntimeMock.Setup(j => j.InvokeAsync<IJSVoidResult>(clipboardWriteTextFunction, It.IsAny<object[]>())).Returns(new ValueTask<IJSVoidResult>());

        // Act
        _clipboardService.CopyToClipboard(textToCopy);

        // Assert
        _jsRuntimeMock.Verify(j => j.InvokeAsync<IJSVoidResult>(clipboardWriteTextFunction, new[] { textToCopy }), Times.Once);
    }

    [Fact]
    public void GivenAClipboardCopyComponent_WhenCopyToClipboardButtonClicked_CallsCopyToClipboard()
    {
        // Arrange
        Services.AddSingleton(_clipboardServiceMock.Object);

        var cut = RenderComponent<CopyToClipboard>();

        // Act
        cut.Find("button").Click();

        // Assert
        _clipboardServiceMock.Verify(c => c.CopyToClipboard(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void GivenAClipboardCopyComponent_WhenInitiallyRendered_ThenMarkupMatchesExpectedOutput()
    {
        // Arrange
        Services.AddSingleton(_clipboardServiceMock.Object);
        const string expectedText = "Copy to Clipboard";
        const string expectedClassList = "btn btn-primary";

        // Act
        var cut = RenderComponent<CopyToClipboard>();

        var button = cut.Find("button");

        // Assert
        Assert.Equal(expectedText, button.TextContent);
        Assert.Equal(expectedClassList, button.ClassName);
    }

    [Fact]
    public void GivenAClipboardCopyComponent_WhenCopyToClipboardButtonClicked_ThenMarkupMatchesExpectedOutput()
    {
        // Arrange
        Services.AddSingleton(_clipboardServiceMock.Object);
        const string expectedText = "Copied to Clipboard";
        const string expectedClassList = "btn btn-success";

        // Act
        var cut = RenderComponent<CopyToClipboard>();

        cut.Find("button").Click();

        // Assert
        var diffs = cut.GetChangesSinceFirstRender();

        diffs.ShouldHaveChanges(
            diff => diff.ShouldBeAttributeChange("class", expectedClassList),
            diff => diff.ShouldBeTextChange(expectedText));
    }

    [Fact]
    public void GivenAClipboardCopyComponentAfterButtonClicked_When2SecondsPasses_ThenMarkupMatchesExpectedOutput()
    {
        // Arrange
        Services.AddSingleton(_clipboardServiceMock.Object);
        const string expectedText = "Copy to Clipboard";

        // Act
        var cut = RenderComponent<CopyToClipboard>();

        var button = cut.Find("button");
        button.Click();

        cut.WaitForState(() => button.TextContent == expectedText, TimeSpan.FromSeconds(3));

        // Assert
        var diffs = cut.GetChangesSinceFirstRender();

        Assert.Empty(diffs);
    }
}