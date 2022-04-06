using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveFromListWhileIterating;

namespace RemoveFromListWhileIteratingTests
{
    [TestClass]
    public class RemoveFromListWhileIteratingTests
    {
        private static readonly List<int> _numberList = Enumerable.Range(1, 20).ToList();
        private static readonly List<int> _oddNumbers = _numberList.Where(i => i % 2 != 0).ToList();

        [TestMethod]
        public void WhenIteratingForward_ThenExceptionIsThrown()
        {
            Assert.ThrowsException<InvalidOperationException>(() => RemoveFromListWhileIteratingProgram.NaiveIterateRemove(_numberList));
        }

        [TestMethod]
        public void WhenIteratingBackwards_RemoveSucceedsAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.ReverseIterate(_numberList);

            CollectionAssert.AreEqual(_oddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, _numberList);
        }

        [TestMethod]
        public void WhenUsingToList_NoExceptionIsThrownAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.SimpleIterateRemoveWithToList(_numberList);

            CollectionAssert.AreEqual(_oddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, _numberList);
        }

        [TestMethod]
        public void WhenUsingRemoveAll_ListIsFilteredAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.OneLineRemoveAll(_numberList);

            CollectionAssert.AreEqual(_oddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, _numberList); 
        }

        [TestMethod]
        public void WhenUsingRemoveAllWithSideEffect_ListIsFilteredAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.OneLineRemoveAllWithSideEffect(_numberList);

            CollectionAssert.AreEqual(_oddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, _numberList);
        }
    }
}