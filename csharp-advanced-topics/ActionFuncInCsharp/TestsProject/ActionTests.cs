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
            var invoicingService = new InvoicingService();

            // act
            invoicingService.GenerateInvoiceWithAction(actionDelegate);
            var invocationList = actionDelegate.GetInvocationList();

            // assert
            Assert.AreEqual(invocationList.Length, 1);
        }

        private void ActionDelegate(string arg)
        {
            // any internl processing
        }
    }
}