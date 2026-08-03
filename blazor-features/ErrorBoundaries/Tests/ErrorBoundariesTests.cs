using Bunit;
using ErrorBoundaries.Pages;
using Xunit;

namespace Tests;
public class ErrorBoundariesTests : TestContext
{
    [Fact]
    public void GivenAValidContext_WhenComponentIsRenderedForFirstTime_ThenRendersCounterComponent()
    {
        // Act
        var cut = RenderComponent<Index>();

        // Assert
        var counter = cut.FindComponent<Counter>();
        Assert.NotNull(counter);
    }

    [Fact]
    public void GivenAValidContext_WhenCounterExceedsFive_ThenErrorIsShown()
    { 
        // Arrange
        const int count = 4;

        // Act
        var cut = RenderComponent<Index>();
        var counter = cut.FindComponent<Counter>();
        var counterButton = counter.Find("button");

        for (var i = 0; i <= count; i++)
        {
            counterButton.Click();
        }

        // Assert
        var error = cut.Find("p");
        error.MarkupMatches("<p class=\"error-message\">Uh oh! Something went wrong</p>");
    }

    [Fact]
    public void GivenComponentInErrorState_WhenResetButtonClicked_ThenStateIsReset()
    {
        // Arrange
        const int count = 4;

        var cut = RenderComponent<Index>();
        var counter = cut.FindComponent<Counter>();
        var counterButton = counter.Find("button");

        for (var i = 0; i <= count; i++)
        {
            counterButton.Click();
        }

        // Act
        var resetButton = cut.Find("button");
        resetButton.Click();

        // Assert
        var counterComponent = cut.FindComponent<Counter>();
        Assert.NotNull(counterComponent);
    }
}