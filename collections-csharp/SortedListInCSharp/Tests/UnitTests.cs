using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using SortedListInCSharp;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        SortedList testNonGenericSortedList;
        SortedList<int, string> testGenericSortedList;

        [TestMethod]
        public void whenGenericSortedListIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = Program.GenericSortedList();
            var expected = typeof(SortedList<int, string>);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenNonGenericSortedListIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = Program.NonGenericSortedList();
            var expected = typeof(SortedList);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenGenericSortedListFromDictionaryIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = Program.GenericSortedListFromDictionary();
            var expected = typeof(SortedList<int, string>);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenGenericSortedListFromDictionaryIsCalled_MethodProducesCorrectListContent()
        {
            var genericSortedList = Program.GenericSortedListFromDictionary();
            Assert.IsTrue(genericSortedList.Count > 0);
        }

        [TestMethod]
        public void whenSortedListWithComparerIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = Program.SortedListWithComparer();
            var expected = typeof(SortedList);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenSortedListWithComparerIsCalled_ResultingListIsSorted()
        {
            var genericSortedList = Program.SortedListWithComparer();
            bool isSorted = true;
            for (var i = 0; i < genericSortedList.Count; i++)
            {
                // Key 1 should be equal to 1, and so forth...
                isSorted = isSorted && (int) genericSortedList.GetKey(i) == (i + 1);
            }
            Assert.IsTrue(isSorted);
        }

        [TestMethod]
        public void whenAddElementsToSortedListIsCalled_MethodProducesCorrectListContent()
        {
            testGenericSortedList = new SortedList<int, string>();

            Program.AddElementsToSortedList(testGenericSortedList);

            Assert.IsTrue(testGenericSortedList.Count > 0);
        }

        [TestMethod]
        public void whenRemoveElementsFromSortedListIsCalled_MethodProducesCorrectListContent()
        {
            testGenericSortedList = new SortedList<int, string>();
            testGenericSortedList.Add(1, "test1");
            testGenericSortedList.Add(2, "test2");
            testGenericSortedList.Add(3, "test3");
            testGenericSortedList.Add(4, "test4");

            Program.RemoveElementsFromSortedList(testGenericSortedList);

            Assert.AreEqual(testGenericSortedList.Count, 0);
        }

        [TestMethod]
        public void whenCheckContentsOfGenericListIsCalledWithKey_MethodMustReturnAccurateValue()
        {
            testGenericSortedList = new SortedList<int, string>();
            testGenericSortedList.Add(1, "test1");
            Assert.IsTrue(Program.CheckContentsOfGenericList(testGenericSortedList, 1));
        }

        [TestMethod]
        public void whenCheckContentsOfGenericListIsCalledWithValue_MethodMustReturnAccurateValue()
        {
            testGenericSortedList = new SortedList<int, string>();
            testGenericSortedList.Add(4, "This is my fourth string element");
            Assert.IsFalse(Program.CheckContentsOfGenericList(testGenericSortedList, "This is my first string element"));
        }

        [TestMethod]
        public void whenCheckContentsOfNonGenericListIsCalledWithKey_MethodMustReturnAccurateValue()
        {
            testNonGenericSortedList = new SortedList();
            testNonGenericSortedList.Add(1, "test1");
            Assert.IsTrue(Program.CheckContentsOfNonGenericList(testNonGenericSortedList, 1));
        }

        [TestMethod]
        public void whenCheckContentsOfNonGenericListIsCalledWithValue_MethodMustReturnAccurateValue()
        {
            testNonGenericSortedList = new SortedList();
            testNonGenericSortedList.Add(4, "This is my fourth string element");
            Assert.IsFalse(Program.CheckContentsOfNonGenericList(testNonGenericSortedList, "This is my first string element"));
        }
    }
}
