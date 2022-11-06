using Bunit;
using CustomEventArguments.Pages;

namespace CustomEventArgumentsTestExample3
{
    public class CustomEventArgumentsTestExample3
    {
        [Fact]
        public void WhenClickTheChildComponentButton_ThenMouseScreenCoordinatesAreReturned()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();
            var Example3Component = ctx.RenderComponent<Example3>();
            var ChildComponent = Example3Component.FindComponent<ChildComponent>();
            var buttonElement = ChildComponent.Find("button");

            // Act
            buttonElement.Click(screenX:325, screenY:240);
            Example3Component.Find("p").MarkupMatches("<p>Mouse coordinates of child component button - (325:240)</p>");
        }
    }
}