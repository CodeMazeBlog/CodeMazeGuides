using InvoiceService;

namespace TestsProject
{
    [TestClass]
    public class ActionTests
    {
        [TestMethod]
        public void ShouldHaveOneActionDelegate()
        {            
            // arrage
            Action<string> actionDelegate = ActionDelegate;
            InvoicingService invoicingService = new InvoicingService();

            // act
            invoicingService.GenerateInvoiceWithAction(actionDelegate);
            var invocationList = actionDelegate.GetInvocationList();

            // assert
            Assert.AreEqual(invocationList.Length, 1);
        }

        // mock delegate action
        private void ActionDelegate(string arg)
        {
            // any internl processing
        }
    }
}