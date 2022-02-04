using Microsoft.VisualStudio.TestTools.UnitTesting;
using IterateThroughDictionary;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryTests
{
    [TestClass]
    public class DictionaryTest
    {
        [TestMethod]
        public void TestDictionaryForIteration()
        {
            Dictionary<int, string> Months = new Dictionary<int, string>
            {
                {1,"January" },
                {2,"February" },
                {3,"March" },
                {4,"April" }
            };

            Dictionary<int, string> ExpectedMonths = new Dictionary<int, string>
            {
                { 1,"January" },
                { 2,"February" },
                { 4,"April" },
                { 3,"March" }

            };

            Program.SubDictionaryUsingForEach(Months);
            Program.SubDictionaryKeyValuePair(Months);
            Program.SubDictionaryForLoop(Months);
            Program.SubDictionaryParallelEnumerable(Months);
            Program.SubDictionaryStringJoin(Months);

            CollectionAssert.AreEquivalent(Months.ToList(), ExpectedMonths.ToList());
            
        }
    }
}