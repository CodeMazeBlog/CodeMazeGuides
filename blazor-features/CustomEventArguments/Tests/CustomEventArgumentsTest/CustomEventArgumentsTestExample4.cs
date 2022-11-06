using Bunit;
using CustomEventArguments.CustomEvents;
using CustomEventArguments.Pages;

namespace CustomEventArgumentsTestExample4
{
    public class CustomEventArgumentsTestExample4
    {
        [Fact]
        public void WhenPasteTextInsideInputElement_ThenPastedTextMessageIsReturned()
        {
            // Arrange
            using var ctx = new TestContext();
            var ComponentExample4 = ctx.RenderComponent<Example4>();

            // Atc - find the input element and trigger the oncustompaste event
            ComponentExample4.Find("input").TriggerEvent("oncustompaste", new CustomPasteEventArgs
            {
                EventTimestamp = DateTime.Now,
                PastedData = "SamplePastedText"
            });

            // Assert that the custom event data was passed correctly
            ComponentExample4.Find("p:last-child").MarkupMatches("<p>At " + DateTime.Now.ToShortTimeString() + ", you pasted: SamplePastedText</p>");
        }
    }
}