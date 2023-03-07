using AngleSharp.Dom;
using BlazorWebAssemblyCustomEvents.Components;
using BlazorWebAssemblyCustomEvents.CustomEvents;
using Bunit;

namespace BlazorWebAssemblyCustomEventsTests
{
    [TestClass]
    public class DoubleClickEventTests
    {
        public IElement? button;
        public IRenderedComponent<DoubleClickButton>? component;

        [TestInitialize]
        public void InitTest()
        {
            var context = new Bunit.TestContext();
            component = context.RenderComponent<DoubleClickButton>();
            button = component.Find("button");
        }

        [TestMethod]
        public void WhenDoubleClickEventRaised_ThenDoubleClickHandlerIsInvoked()
        {
            button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = true
            });

            var headerText = component?.FindAll("h1")[1].TextContent;

            Assert.AreEqual("detected double click!", headerText);
        }

        [TestMethod]
        public void WhenClickEventRaised_GivenLastInteractionWasADoubleClick_ThenMessageIsReset()
        {
            button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = true
            });

            button?.TriggerEvent("ondoubleclick", new DoubleClickEventArgs
            {
                EventTimestamp = DateTime.Now,
                IsDoubleClick = false
            });

            var headerText = component?.FindAll("h1")[1].TextContent;

            Assert.AreEqual("", headerText);
        }
    }
}