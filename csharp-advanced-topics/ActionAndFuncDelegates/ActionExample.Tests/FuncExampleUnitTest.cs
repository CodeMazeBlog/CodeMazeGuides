using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Tests
{
    [TestClass]
    public class FuncExampleUnitTest
    {
        static int MyAddFuction(int x, int y)
        {
            return x + y;
        }
        [TestMethod]
        public void givenFuncDelegate_whenSendingParameters_thenReturnValuesAreEqual()
        {
            Func<int, int, int> myFuncDelegate = MyAddFuction;
            int result = myFuncDelegate(2, 3); 
            
            Assert.AreEqual(5, result);
        }
    }
}
