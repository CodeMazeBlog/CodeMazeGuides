using IEnumeralbleVsICollectionVsIListVsList;
using NUnit.Framework;

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
        public void WhenICollection_ThenCharacter_HaveAddRead()
        {
            var icl = new ImplementationOfICollection();
            ICollection<char> lst = new List<char>() { '^', '.' };

            Assert.That(icl.CountSpecialCharacters(lst), Is.EqualTo(4));
        }

        [Test]
        public void WhenIList_ThenCharacter_HaveAddInsertIndexOfRead()
        {
            var ils = new ImplementationOfIList();
            IList<char> lst = new List<char>() { '^', '.' };

            Assert.That(ils.CountSpecialCharacters(lst), Is.EqualTo(5));
        }

        [Test]
        public void WhenList_ThenCharacter_AllMethods()
        {
            var lst = new ImplementationOfList();

            Assert.That(lst.ListOfSpecialCharacters().Count(), Is.EqualTo(3));
        }
    }
}