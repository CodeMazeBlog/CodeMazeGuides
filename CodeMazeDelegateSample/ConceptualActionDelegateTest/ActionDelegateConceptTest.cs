using ConceptualActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ConceptualActionDelegateTest
{
    [TestClass]
    public class ActionDelegateConceptTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);

                Foo foo = new Foo("Hello Action Delegate!!");
                Action actionFunctionPointer = foo.Echo;
                actionFunctionPointer();

                Assert.IsTrue(stringWriter.ToString().Contains("Hello Action Delegate!!"));
            }
        }
    }
}
