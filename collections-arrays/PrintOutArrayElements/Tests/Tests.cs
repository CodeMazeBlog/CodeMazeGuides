using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrintOutArrayElements;
using System;
using System.IO;
using System.Text;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly ElementPrinter _elementPrinter = new();
        private static readonly int[] _array = new int[] { 1, 4, 6, 7, 9, 3, 5 };
        private const string _expectedResult = " ==> 1 ==> 4 ==> 6 ==> 7 ==> 9 ==> 3 ==> 5";
        private static readonly StringBuilder _consoleOutput = new();

        [TestInitialize]
        public void Init()
        {
            Console.SetOut(new StringWriter(_consoleOutput));
            _consoleOutput.Clear();
        }

        [TestMethod]
        public void GivenTheClassProgram_WhenExecuteTheMainMethod_ThenSetTheOutPutResultToOne()
        {
            Program.Main(Array.Empty<string>());

            Assert.AreEqual(1, Program.OutPutResult);
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingForLoop_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.ForLoop(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingForeachLoop_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.ForeachLoop(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingAsSpan_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.AsSpan(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingToListForEach_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.ToListForEach(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingStringJoin_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.StringJoin(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }

        [TestMethod]
        public void GivenAnArray_WhenUsingArrayForEach_ThenPrintOutTheResultOnTheScreen()
        {
            _elementPrinter.ArrayForEach(_array);

            Assert.AreEqual(_expectedResult, _consoleOutput.ToString());
        }
    }
}