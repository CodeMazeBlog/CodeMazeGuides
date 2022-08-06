using InvoiceService;

namespace TestsProject
{
    [TestClass]
    public class ActionTest
    {
        [TestMethod]
        public void GivenFunction_WhenOneActionDelegatePassed_ShouldHaveOneDeletageLinked()
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