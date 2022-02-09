using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ActionAndFuncDelegatesTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_FuncDelegate()
        {

            //Arrange
            int expected = 10;
            int a = 7;
            int b = 3;

            //Act

         int actual =   Delegates.Lib.DelegatesLibrary.AddTwoNumbers(a,b);

            //Assert

            Assert.AreEqual(expected, actual);
        }



        public void Test_ActionDelegate()
        {

            //Arrange
            var expected = "" ;
            var actual = "";
            int startPosition = 5;
            int target = 20;

            //Act

          

           Delegates.Lib.DelegatesLibrary.PrintNumbers(startPosition, target);

            //Assert

            Assert.AreEqual(expected, actual);
        }

    }
}
