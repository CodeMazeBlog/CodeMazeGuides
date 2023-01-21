using IEnumeralbleVsICollectionVsIListVsList;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Tests
    {      
        [Test]
        public void WhenIEnumerable_ThenCharacter_HaveReadOnly()
        {
            var ien = new ImplementationOfIEnumerable();
            IEnumerable<char> lst = new List<char>() { '^', '.' };

            Assert.That(ien.CountSpecialCharacters(lst), Is.EqualTo(2));
        }

        [Test]
        public void WhenIEnumerableWithYield_ThenFilterNumber()
        {
            var ien = new ImplementationOfIEnumerable();
            var numbers = new List<int>() { 1, 2, 3 };

            Assert.That(ien.FilterNumbers(numbers).Sum(), Is.EqualTo(3));
        }

        [Test]
        public void WhenICollection_ThenCharacter_HaveAddRead()
        {
            var icl = new ImplementationOfICollection();
            ICollection<char> lst = new List<char>() { '^', '.' };

            Assert.That(icl.CountSpecialCharacters(lst), Is.EqualTo(4));
        }

        [Test]
        public void WhenIList_HaveListInput()
        {
            var ils = new ImplementationOfIList();
            IList<char> lst = new List<char>() { '^', '.' };

            Assert.That(ils.CountSpecialCharacters(lst), Is.EqualTo(5));
        }

        [Test]
        public void WhenIList_HaveArrayInput()
        {
            var ils = new ImplementationOfIList();
            char[] arr = new char[] { '^', '.' };

            Assert.That(ils.CountSpecialCharactersArray(arr), Is.EqualTo(2));
        }

        [Test]
        public void WhenList_HaveOnlyListInput()
        {
            var lst = new ImplementationOfList();
            List<char> lt = new List<char>() { '^' ,'(', ')'};

            Assert.That(lst.CountSpecialCharacters(lt), Is.EqualTo(3));
        }
    }
}