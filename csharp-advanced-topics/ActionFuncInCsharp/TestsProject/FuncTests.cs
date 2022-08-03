using InvoiceService;

namespace TestsProject
{
    [TestClass]
    public class FuncTests
    {
        [TestMethod]
        public void ShouldHaveOneFuncDelegate()
        {            
            // arrange
            Func<decimal, decimal> funcDelegate = FuncDelegate;
            var invoicingService = new InvoicingService();

            // act
            invoicingService.GenerateInvoiceWithFunc(10, funcDelegate);
            var invocationList = funcDelegate.GetInvocationList();

            // assert
            Assert.AreEqual(invocationList.Length, 1);
            
        }

        private decimal FuncDelegate(decimal arg)
        {
            return arg + (arg * 0.2M);
        }
    }
}