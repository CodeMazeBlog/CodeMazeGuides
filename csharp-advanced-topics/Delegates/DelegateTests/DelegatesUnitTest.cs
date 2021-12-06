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

        //test that the action delegate is executed
        //the test makes sure the returned result is correct
        [TestMethod]
        public void whenActionDelegateisExecuted_thenShowResults() 
        {
            int first = 20;
            int second = 20;

            //calculate the product of first and second number
            int product = Program.CalcProduct(first, second);

            //define a string writer variable to captur console output
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            //calculate the product of two numbers
            Program.PrintProduct(product);
            string expectedOutput = "The product is 400\r\n";
            string actualOutput = ""+ stringWriter.ToString();

            //compare whether the action delegate outputs the same result as the expected string
            int actual = String.Compare(expectedOutput, actualOutput, StringComparison.OrdinalIgnoreCase);
            int expected = 0;
            Assert.AreEqual(actual, expected);
            
        }
    }
}
