using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delegates;
using System;
using System.Diagnostics;
using System.IO;

namespace DelegateTests
{
    [TestClass]
    public class DelegatesUnitTest
    {

        //when given two numbers, assert the product is correct
        //this test checks whether the func delegate returns the correct product
        [TestMethod]
        public void whenMultiplyingTwoNumbers_thenCorrrectProduct()
        {
            int first = 20;
            int second = 20;
            int expected = 400;

            //call the method to calculate the product of two numbers
            int actual = Program.CalcProduct(first, second);

            //check whether the expected and actual values are equal
            Assert.AreEqual(expected, actual);
        }

        //test func delegate's return type to be int
        [TestMethod]
        public void whenDefiningFuncDelegate_thenCorrectReturnType() 
        {
            int firstNum = 30;
            int secondNum = 0;
            int actual = Program.CalcProduct(firstNum, secondNum);

            //checks if the returned value if of type int
            Assert.IsInstanceOfType(actual, typeof(int));
        }

    }
}
