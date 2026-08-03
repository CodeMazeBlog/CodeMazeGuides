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
            var genericSortedList = GenericLists.GenericSortedList();
            var expected = typeof(SortedList<int, string>);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenNonGenericSortedListIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = NonGenericLists.NonGenericSortedList();
            var expected = typeof(SortedList);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenGenericSortedListFromDictionaryIsCalled_MethodProducesCorrectListType()
        {
            var genericSortedList = GenericLists.GenericSortedListFromDictionary();
            var expected = typeof(SortedList<int, string>);
            var output = genericSortedList.GetType();
            Assert.AreEqual(output, expected);
        }

        [TestMethod]
        public void whenGenericSortedListFromDictionaryIsCalled_MethodProducesCorrectListContent()
        {
            var genericSortedList = GenericLists.GenericSortedListFromDictionary();
            Assert.IsTrue(genericSortedList.Count > 0);
        }

        [TestMethod]
        public void whenAddElementsToSortedListIsCalled_MethodProducesCorrectListContent()
        {
            testGenericSortedList = new SortedList<int, string>();

            GenericLists.AddElementsToSortedList(testGenericSortedList);

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

            GenericLists.RemoveElementsFromSortedList(testGenericSortedList);

            Assert.AreEqual(testGenericSortedList.Count, 0);
        }

        [TestMethod]
        public void whenCheckContentsOfGenericListIsCalledWithKey_MethodMustReturnAccurateValue()
        {
            testGenericSortedList = new SortedList<int, string>();
            testGenericSortedList.Add(1, "test1");
            Assert.IsTrue(GenericLists.CheckContentsOfGenericList(testGenericSortedList, 1));
        }

        [TestMethod]
        public void whenCheckContentsOfGenericListIsCalledWithValue_MethodMustReturnAccurateValue()
        {
            testGenericSortedList = new SortedList<int, string>();
            testGenericSortedList.Add(4, "This is my fourth string element");
            Assert.IsFalse(GenericLists.CheckContentsOfGenericList(testGenericSortedList, "This is my first string element"));
        }

        [TestMethod]
        public void whenCheckContentsOfNonGenericListIsCalledWithKey_MethodMustReturnAccurateValue()
        {
            testNonGenericSortedList = new SortedList();
            testNonGenericSortedList.Add(1, "test1");
            Assert.IsTrue(NonGenericLists.CheckContentsOfNonGenericList(testNonGenericSortedList, 1));
        }

        [TestMethod]
        public void whenCheckContentsOfNonGenericListIsCalledWithValue_MethodMustReturnAccurateValue()
        {
            testNonGenericSortedList = new SortedList();
            testNonGenericSortedList.Add(4, "This is my fourth string element");
            Assert.IsFalse(NonGenericLists.CheckContentsOfNonGenericList(testNonGenericSortedList, "This is my first string element"));
        }
    }
}
