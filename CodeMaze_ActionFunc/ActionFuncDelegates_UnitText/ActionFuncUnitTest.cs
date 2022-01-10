using ActionFuncDelegates_Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
namespace ActionFuncDelegates_UnitText
{
    [TestClass]
    public class ActionFuncUnitTest
    {
        [TestMethod]
        public void DelegateTestMethod()
        {
            //initialize or arrange parameters

            double principalAmount = 500;
            double expectedResult = 75;
            //act
            ActionFuncDelegates.ExecuteInstantiatedCustomDelegate(principalAmount);

            //get execution result
            double total = ActionFuncDelegates.Result; //to check failure replace with any number

            // Assert
            double actual = total;
            Assert.AreEqual(expectedResult, actual, "valid");

        }
        [TestMethod]
        public void DelegateWithParamentersTestMethod()
        {
            //initialize or arrange parameters

            int firstNum = 20;
            int secondNum = 20;
            double expectedResult = 40;
            //act
            ActionFuncDelegates.ExecuteDelegateWithParamenters(firstNum, secondNum);

            //get execution result
            double total = ActionFuncDelegates.Result;

            // Assert
            double actual = total;
            Assert.AreEqual(expectedResult, actual, "Valid");

        }



    }
}
