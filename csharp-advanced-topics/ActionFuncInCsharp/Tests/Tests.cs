using ActionFuncInCsharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void whenPredicateDelegateSet_MustReturnMatchingRecord()
        {
            var personList = new PersonList();
            var result = personList.WhereWithDelegate(p => p.Name == "Murat").FirstOrDefault();
            Assert.AreEqual(result?.Name, "Murat");
        }

        [TestMethod]
        public void whenPredicateFuncSet_MustReturnMatchingRecord()
        {
            var personList = new PersonList();
            var result = personList.WhereWithFunc(p => p.Name == "Murat").FirstOrDefault();
            Assert.AreEqual(result?.Name, "Murat");
        }

        [TestMethod]
        public void whenDelegateIsSet_DelegateExecutesTheReferencedMethod()
        {
            var declarations = new Declarations();
            var result = declarations.returnMultiplicationDelegateRefer(2, 3);
            Assert.AreEqual(result, 2 * 3);
        }

        [TestMethod]
        public void whenFuncDelegateIsSet_FuncDelegateExecutesTheReferencedMethod()
        {
            var declarations = new Declarations();
            var result = declarations.returnMultiplicationFuncDelegateRefer(2, 3);
            Assert.AreEqual(result, 2 * 3);
        }
    }
}