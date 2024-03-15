using IEnumerableVsICollectionVsIListVsList;
using NUnit.Framework;

namespace Tests
{
    public class CollectionInterfacesUnitTest
    {      
        [Test]
        public void WhenIEnumerable_ThenWeHaveReadOnly()
        {
            var ien = new ImplementationOfIEnumerable();
            IEnumerable<char> lst = new List<char>() { '^', '.' };

            Assert.That(ien.CountSpecialCharacters(lst), Is.EqualTo(2));
        }

        [Test]
        public void WhenIEnumerableWithYield_ThenWeCustomIterateWithRead()
        {
            var ien = new ImplementationOfIEnumerable();

            Assert.That(ien.GetEvenNumberUpToTen().Sum(), Is.EqualTo(30));
        }

        [Test]
        public void WhenICollection_ThenWePerformNonIndexedOperations()
        {
            var icl = new ImplementationOfICollection();
            ICollection<char> lst = new List<char>() { '^', '.' };

            Assert.That(icl.CountSpecialCharacters(lst), Is.EqualTo(4));
        }

        [Test]
        public void WhenIList_ThenWePerformIndexedOperationsWithList()
        {
            var ils = new ImplementationOfIList();
            IList<char> lst = new List<char>() { '^', '.' };

            Assert.That(ils.CountSpecialCharacters(lst), Is.EqualTo(5));
        }

        [Test]
        public void WhenIList_ThenWePerformIndexedOpeartionsWithArray()
        {
            var ils = new ImplementationOfIList();
            char[] arr = new char[] { '^', '.' };

            Assert.That(ils.CountSpecialCharactersArray(arr), Is.EqualTo(2));
        }

        [Test]
        public void WhenList_WePerformAllAboveOperations()
        {
            var lst = new ImplementationOfList();
            List<char> lt = new List<char>() { '^' ,'(', ')'};

            Assert.That(lst.CountSpecialCharacters(lt), Is.EqualTo(3));
        }

        [Test]
        public void WhenPassedArrayToIList_ThrowsException()
        {
            var ils = new ImplementationOfIList();
            char[] arr = new char[] { '^', '.' };
            var output = Assert.Throws<NotSupportedException>(() => ils.CountSpecialCharacters(arr));

            Assert.That(output.Message == "Collection was of a fixed size.");
        }
    }
}