using FuncAndActionDelegate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void GivenTwoNumbers_ThenReturnTheSumofTwoNumbers()
        {
            var addResult = Program.Add(4, 7);
            Assert.AreEqual(11, addResult);
        }

        [TestMethod]
        public void GivenTwoNumbers_ThenReturnTheSubtractionOfTwoNumbers()
        {
            var subtractionResult = Program.Subtract(7, 4);
            Assert.AreEqual(3, subtractionResult);
        }

        [TestMethod]
        public void GivenTwoNumbers_ThenWriteTheSumAtTheConsole()
        {
            Program.AddAction(4, 7);
            Assert.AreEqual(11, Program.OutputResult);
        }

        [TestMethod]
        public void GivenTwoNumbers_ThenWriteTheSubtractionAtTheConsole()
        {
            Program.SubtractAction(7, 4);
            Assert.AreEqual(3, Program.OutputResult);
        }

        [TestMethod]
        public void GivenTheClassProgram_ThenExecuteTheWholeMainMethod()
        {
            Program.Main(new string[] {});
            Assert.AreEqual(1, Program.OutputResult);
        }
        
        [TestMethod]
        public void GivenTwoNumbersAndTheAddAction_ThenCreateAnActionAndExecuteIt()
        {
            Action<int, int> add = Program.AddAction;
            add(3, 7);

            Assert.AreEqual(10, Program.OutputResult);
        }

        [TestMethod]
        public void GivenTwoNumbersAndTheSubtractAction_ThenCreateAnActionAndExecuteIt()
        {
            Action<int, int> subtract = Program.SubtractAction;
            subtract(7, 3);

            Assert.AreEqual(4, Program.OutputResult);
        }

        [TestMethod]
        public void GivenTwoNumbersAndTheAddFunction_ThenCreateAFunctionAndExecuteIt()
        {
            Func<int, int, int> add = Program.Add;
            var result = add(3, 7);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void GivenTwoNumbersAndTheSubtractFunction_ThenCreateAFunctionAndExecuteIt()
        {
            Func<int, int, int> subtract = Program.Subtract;
            var result = subtract(7, 3);
            Assert.AreEqual(4, result);
        }

        public delegate int Add(int firstValue, int secondValue);
        [TestMethod]
        public void GivenTwoNumbersAndTheAddMethod_ThenCreateADelegateAndExecuteIt()
        {
            Add add = Program.Add;
            var result = add(3, 7);

            Assert.AreEqual(10, result);
        }

        public delegate int Subtract(int firstValue, int secondValue);
        [TestMethod]
        public void GivenTwoNumbersAndTheSubtractMethod_ThenCreateADelegateAndExecuteIt()
        {
            Subtract subtract = Program.Subtract;
            var result = subtract(7, 3);

            Assert.AreEqual(4, result);
        }
    }
}