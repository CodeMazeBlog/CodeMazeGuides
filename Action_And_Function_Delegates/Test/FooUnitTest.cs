using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tests
{
    [TestClass]
    public class FooUnitTest
    {
        private const string Fun_Del_Expected = "64.00";
        [TestMethod]
        public void Func_Delegate_TestMethod()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Func_Delegates.Pages.Shared.Func_Delegate_Class.Main();

                  var result = sw.ToString().Trim();
                Assert.AreEqual(Fun_Del_Expected, result);
            }
        }


        private const string Action_Del_Expected = "Ricky Martin";
        [TestMethod]
        public void Action_Delegate_TestMethod()
        {
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                Action_Delegates.Pages.Shared.Action_Delegate_Class.Main();

                var result = sw.ToString().Trim();
                Assert.AreEqual(Action_Del_Expected, result);
            }
        }
    }
}