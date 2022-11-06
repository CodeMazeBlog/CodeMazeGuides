using Bunit;
using CustomEventArguments.CustomEvents;
using CustomEventArguments.Pages;

namespace CustomEventArgumentsTestExample4
{
    public class CustomEventArgumentsTestExample5
    {
        [Fact]
        public void WhenCutTextInsideInputElement_ThenCutTextMessageIsReturned()
        {
            // Arrange
            using var ctx = new TestContext();
            var ComponentExample5 = ctx.RenderComponent<Example5>();

            // Atc - find the input element and trigger the oncustompaste event
            ComponentExample5.Find("input").TriggerEvent("oncustomcut", new CustomCutEventArgs
            {
                EventTimestamp = DateTime.Now,
                CutData = "SampleCutText"
            });

            // Assert that the custom event data was passed correctly
            ComponentExample5.Find("#text").MarkupMatches("<p id=\"text\"> At "  + DateTime.Now.ToShortTimeString() + ", The cut text is: SampleCutText</p>");
        }

        [Fact]
        public void WhenCopyTextInsideInputElement_ThenCopiedTextMessageIsReturned()
        {
            // Arrange
            using var ctx = new TestContext();
            var ComponentExample5 = ctx.RenderComponent<Example5>();

            // Atc - find the input element and trigger the oncustompaste event
            ComponentExample5.Find("input").TriggerEvent("oncustomcopy", new CustomCopyEventArgs
            {
                EventTimestamp = DateTime.Now,
                CopiedData = "SampleCopiedText"
            });

            // Assert that the custom event data was passed correctly
            ComponentExample5.Find("#text").MarkupMatches("<p id=\"text\"> At " + DateTime.Now.ToShortTimeString() + ", The copied text is: SampleCopiedText</p>");
        }
    }
}