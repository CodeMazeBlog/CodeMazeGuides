using VirtualMethodsInCSharp;

namespace Tests
{
    [TestClass]
    public class VirtualMethodsInCSharpUnitTests
    {
        [TestMethod]
        public void WhenBaseClassVirtualMethodA_ThenBaseClassVirtualMethodAResult()
        {
            var baseClass = new BaseClass();
            var baseClassVirtualMethodA = baseClass.VirtualMethodA();

            Assert.AreEqual("This is a virtual method", baseClassVirtualMethodA);
        }

        [TestMethod]
        public void WhenBaseClassVirtualMethodB_ThenBaseClassVirtualMethodBResult()
        {
            var baseClass = new BaseClass();
            var baseClassVirtualMethodB = baseClass.VirtualMethodB();

            Assert.AreEqual("This is another virtual method", baseClassVirtualMethodB);
        }

        [TestMethod]
        public void WhenBaseClassNonVirtualMethod_ThenBaseClassNonVirtualMethodResult()
        {
            var baseClass = new BaseClass();
            var baseClassNonVirtualMethod = baseClass.NonVirtualMethod();

            Assert.AreEqual("This is non-virtual method", baseClassNonVirtualMethod);
        }

        [TestMethod]
        public void WhenDerivedClassVirtualMethodA_ThenDerivedClassVirtualMethodAResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassVirtualMethodA = derivedClass.VirtualMethodA();

            Assert.AreEqual("This method overrides a virtual method", derivedClassVirtualMethodA);
        }

        [TestMethod]
        public void WhenDerivedClassVirtualMethodB_ThenDerivedClassVirtualMethodBResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassVirtualMethodB = derivedClass.VirtualMethodB();

            Assert.AreEqual("This is another virtual method", derivedClassVirtualMethodB);
        }

        [TestMethod]
        public void WhenDerivedClassNonVirtualMethod_ThenDerivedClassNonVirtualMethodResult()
        {
            var derivedClass = new DerivedClass();
            var derivedClassNonVirtualMethod = derivedClass.NonVirtualMethod();

            Assert.AreEqual("This method hides the inherited non-virtual method", derivedClassNonVirtualMethod);
        }
    }
}