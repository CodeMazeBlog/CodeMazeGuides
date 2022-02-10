using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IterateThroughDictionary;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace DictionaryTests
{
    [TestClass]
    public class DictionaryTest
    {
        public static readonly string Month_January = "1 : January";
        public static readonly string Month_February = "2 : February";
        public static readonly string Month_March = "3 : March";
        public static readonly string Month_April = "4 : April";
        public static readonly string Month_January_StringJoin = "[1, January]";

        StringWriter stringWrite = new StringWriter();

        public DictionaryTest()
        {
            Console.SetOut(stringWrite);
        }

        static Dictionary<int, string> Months = new Dictionary<int, string>
        {
            {1,"January" },
            {2,"February" },
            {3,"March" },
            {4,"April" }
         };

        [TestMethod]
        public void whenDictionaryUsesForEachloop()
        {
            Program.SubDictionaryUsingForEach(Months);
            
            var outputLines = stringWrite.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(Month_January, outputLines[0]);
            Assert.AreEqual(Month_February, outputLines[1]);
            Assert.AreEqual(Month_March, outputLines[2]);
            Assert.AreEqual(Month_April, outputLines[3]);
        }

        [TestMethod]
        public void whenDictionaryUsesKeyValuePair()
        {
            Program.SubDictionaryKeyValuePair(Months);
            
            var outputLines = stringWrite.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(Month_January, outputLines[0]);
            Assert.AreEqual(Month_February, outputLines[1]);
            Assert.AreEqual(Month_March, outputLines[2]);
            Assert.AreEqual(Month_April, outputLines[3]);
        }

        [TestMethod]
        public void whenDictionaryUsesForLoop()
        {
            Program.SubDictionaryForLoop(Months);
            
            var outputLines = stringWrite.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(Month_January, outputLines[0]);
            Assert.AreEqual(Month_February, outputLines[1]);
            Assert.AreEqual(Month_March, outputLines[2]);
            Assert.AreEqual(Month_April, outputLines[3]);
        }

        [TestMethod]
        public void whenDictionaryUsesParallelEnumerable()
        {
            Program.SubDictionaryParallelEnumerable(Months);
            
            var resultlines = stringWrite.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(Month_January, resultlines[0]);
            Assert.AreEqual(Month_February, resultlines[1]);
            Assert.AreEqual(Month_March, resultlines[2]);
            Assert.AreEqual(Month_April, resultlines[3]);
        }

        [TestMethod]
        public void whenDictionaryUsesStringJoin()
        {
            Program.SubDictionaryStringJoin(Months);
            
            var outputLines = stringWrite.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

            Assert.AreEqual(Month_January_StringJoin, outputLines[0]);
        }
    }


}
