using Microsoft.VisualStudio.TestTools.UnitTesting;
using ActionFuncDelegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Diagnostics;

namespace Tests
{
    [TestClass()]
    public class DelegateDemoTests
    {
        StringWriter stringWriter = new StringWriter();

        public DelegateDemoTests()
        {
            //Arrange
            Console.SetOut(stringWriter);
        }


        [TestMethod]
        public void WhenActionDelegateInvoked_ThenCorrectValueDisplayed()
        {
            //Act
            Program.greet("PHP");
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var expected = "Welcome to PHP demo!";
            
            //Assert
            Assert.AreEqual(output[0], expected);
        }
      
        [TestMethod]
        public void WhenFuncDelegateInvoked_ThenCorrectValueDisplayed()
        {                      
            var expected = Program.convertMethod("florida");
            
            Assert.AreEqual(expected, "Florida");
        }
    }
}