using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        delegate int DelegateOfMethod(int x);
        private static int Product(int x) => x * x;
        private static int MethodUsesDelegate(DelegateOfMethod del, int x) => del(x);

        //another method
        private static int Sum(int x) => x + x;

        [TestMethod]
        public void GivenInteger_ProductReturnValue_EqualsDelegateReturnValue()
        {
            int methodOp = Product(5);
            int delegateOp = new DelegateOfMethod(Product)(5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenInteger_SumReturnValue_EqualsDelegateReturnValue()
        {
            int methodOp = Sum(5);
            int delegateOp = new DelegateOfMethod(Sum)(5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenInteger_MethodReturnValue_EqualsDelegateReturnValue_Sum()
        {
            int methodOp = Sum(5);
            int delegateOp = MethodUsesDelegate(new DelegateOfMethod(Sum), 5);
            Assert.AreEqual(methodOp, delegateOp);
        }
        [TestMethod]
        public void GivenInteger_MethodReturnValue_EqualsDelegateReturnValue_Product()
        {
            int methodOp = Product(5);
            int delegateOp = MethodUsesDelegate(new DelegateOfMethod(Product), 5);
            Assert.AreEqual(methodOp, delegateOp);
        }
    }
   

}
