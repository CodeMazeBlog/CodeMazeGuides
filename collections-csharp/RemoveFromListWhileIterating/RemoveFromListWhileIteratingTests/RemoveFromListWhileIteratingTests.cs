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
        private static List<int> NumberList = Enumerable.Range(1, 20).ToList();
        private static List<int> NumberListCopy = Enumerable.Range(1, 20).ToList();
        private static List<int> OddNumbers = NumberList.Where(i => i % 2 != 0).ToList();

        [TestMethod]
        public void WhenIteratingForward_ThenExceptionIsThrown()
        {
            Assert.ThrowsException<InvalidOperationException>(() => RemoveFromListWhileIteratingProgram.NaiveIterateRemove(NumberList));
        }

        [TestMethod]
        public void WhenIteratingBackwards_RemoveSucceedsAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.ReverseIterate(NumberList);
            CollectionAssert.AreEqual(OddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, NumberList);
        }

        [TestMethod]
        public void WhenUsingToList_NoExceptionIsThrownAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.SimpleIterateRemoveWithToList(NumberList);
            CollectionAssert.AreEqual(OddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, NumberList);
        }

        [TestMethod]
        public void WhenUsingRemoveAll_ListIsFilteredAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.OneLineRemoveAll(NumberList);
            CollectionAssert.AreEqual(OddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, NumberList); 
        }

        [TestMethod]
        public void WhenUsingRemoveAllWithSideEffect_ListIsFilteredAndOriginalIsModified()
        {
            var filteredList = RemoveFromListWhileIteratingProgram.OneLineRemoveAllWithSideEffect(NumberList);
            CollectionAssert.AreEqual(OddNumbers, filteredList);
            CollectionAssert.AreEqual(filteredList, NumberList);
        }
    }
}