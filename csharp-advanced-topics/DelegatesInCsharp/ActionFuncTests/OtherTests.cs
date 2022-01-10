using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace ActionFunc.Tests
{
    [TestClass()]
    public class OtherTests
    {
        [TestMethod()]
        public void AnonymousFuncTest()
        {
            try
            {
                int a = 3;
                int b = 9;
                string expected = "27";
                Func<int, int, string> myAnonimousFunc = (a, b) => { return $"{a * b}"; };
                var result = myAnonimousFunc(a, b);
                Assert.AreEqual(expected, result);
            }
            catch
            { Assert.IsTrue(false); }
        }

        [TestMethod()]
        public void AnonymousActionTest()
        {
            try
            {
                Action<string> myAnonymousAction = x => { Console.WriteLine($"Hello anonymous {x}"); };
                myAnonymousAction("Peter");
                Assert.IsTrue(true);
            }
            catch
            { Assert.IsTrue(false); }
        }

        [TestMethod()]
        public void IEnumerableTest()
        {
            try
            {
                string[] names = { "Peter", "John", "Robert", "Lucille" };
                foreach (var item in names.Select(x => x.ToUpper()))
                {
                    Console.WriteLine(item);
                }

                foreach (var item in names.Select((name, index) => $"{name} ({index})"))
                {
                    Console.WriteLine(item);
                }
                Assert.IsTrue(true);
            }
            catch
            { Assert.IsTrue(false); }
        }
    }
}