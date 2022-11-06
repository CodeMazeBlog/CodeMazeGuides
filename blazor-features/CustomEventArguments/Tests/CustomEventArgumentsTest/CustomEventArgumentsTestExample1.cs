using Bunit;
using CustomEventArguments.Pages;

namespace CustomEventArgumentsTestExample1
{
    public class CustomEventArgumentsTestExample1
    {
        [Fact]
        public void WhenMovingTheMouseInsideTheImage_ThenMouseCoordinatesAreReturned()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();

            var ComponentExample1 = ctx.RenderComponent<Example1>();

            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            ComponentExample1.Find("img").MouseMove(0,0,0,383,225);

            // Assert: first find the <p> element, then verify its content
            ComponentExample1.Find("p").MarkupMatches("<p>X = 383 Y = 225</p>");
        }
    }
}