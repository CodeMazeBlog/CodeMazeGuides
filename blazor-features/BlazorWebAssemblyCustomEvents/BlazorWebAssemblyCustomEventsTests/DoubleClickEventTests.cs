using AngleSharp.Dom;
using BlazorWebAssemblyCustomEvents.Components;
using BlazorWebAssemblyCustomEvents.CustomEvents;
using Bunit;

namespace BlazorWebAssemblyCustomEventsTests
{
    [TestClass]
    public class DoubleClickEventTests
    {
        private readonly IElement? _button;
        private readonly IRenderedComponent<DoubleClickButton>? _component;

        public DoubleClickEventTests()
        {
            var context = new Bunit.TestContext();
            _component = context.RenderComponent<DoubleClickButton>();
            _button = _component.Find("button");
        }

        [TestMethod]
        public void WhenDoubleClickEventRaised_ThenDoubleClickHandlerIsInvoked()
        {
            _button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = true
            });

            var headerText = _component?.FindAll("h1")[1].TextContent;

            Assert.AreEqual("detected double click!", headerText);
        }

        [TestMethod]
        public void WhenClickEventRaised_GivenLastInteractionWasADoubleClick_ThenMessageIsReset()
        {
            _button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = true
            });

            _button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = false
            });

            var headerText = _component?.FindAll("h1")[1].TextContent;

            Assert.AreEqual("", headerText);
        }
    }
}