using Bunit;
using CustomEventArguments.Pages;

namespace CustomEventArgumentsTestExample2
{
    public class CustomEventArgumentsTestExample2
    {
        [Fact]
        public void WhenMovingTheMouseInsideTheImage_ThenMouseCoordinatesAreReturned()
        {
            // Arrange: render the Counter.razor component
            using var ctx = new TestContext();

            var ComponentExample2 = ctx.RenderComponent<Example2>();

            // Act: find and click the <button> element to increment
            // the counter in the <p> element
            ComponentExample2.Find("img").MouseMove(0,0,0,390,230);

            // Assert: first find the <p> element, then verify its content
            ComponentExample2.Find("p").MarkupMatches("<p>X = 390 Y = 230</p>");
        }
    }
}