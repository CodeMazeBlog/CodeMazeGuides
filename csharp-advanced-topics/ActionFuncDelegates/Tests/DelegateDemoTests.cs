using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Tests
{
    [TestClass()]
    public class DelegateDemoTests
    {
        static string Titlecase(string inputString)
        {
            var textinfo = new CultureInfo("en-US", false).TextInfo;
            return textinfo.ToTitleCase(inputString);
        }

        [TestMethod]
        public void whenActionDelegate_DelegateInvocationListNotEmpty()
        {
            Action<string> greet = lang => Console.WriteLine($"Welcome to {lang} demo!");
            var invocationList = greet.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }

        [TestMethod]
        public void whenFuncDelegate_DelegateInvocationListNotEmpty()
        {
            Func<string, string> convert = Titlecase;
            var invocationList = convert.GetInvocationList();
            Assert.AreEqual(invocationList.Length, 1);
        }
    }
}