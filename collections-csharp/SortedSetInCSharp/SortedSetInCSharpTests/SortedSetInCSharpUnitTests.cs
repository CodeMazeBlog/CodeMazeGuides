using SortedSetInCSharp;

namespace SortedSetInCSharpTests
{
    [TestClass]
    public class SortedSetInCSharpUnitTests
    {
        private readonly SortedSetMethods _sortedSet; 
        private readonly SortedSet<string> _languages;

        public SortedSetInCSharpUnitTests()
        {
            _sortedSet = new SortedSetMethods();
            _languages = _sortedSet.ProgrammingLanguages();
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyCountAndContains()
        {
            Assert.IsInstanceOfType(_languages, typeof(SortedSet<string>));
            Assert.AreEqual(_languages.Count(), 9);
            Assert.IsTrue(_languages.Contains("Java"));
            Assert.AreEqual(_languages.First(), "C");
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyHasNoDuplicates()
        {
            _languages.Add("C");
            _languages.Add("C++");
            _languages.Add("C#");

            Assert.IsInstanceOfType(_languages, typeof(SortedSet<string>));
            Assert.AreEqual(_languages.Count(), 9);
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyOverlapsSuccessful()
        {
            var commonLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };
            var differentLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            Assert.IsTrue(commonLanguages.Overlaps(_languages));
            Assert.IsTrue(differentLanguages.Overlaps(commonLanguages));
            Assert.IsFalse(differentLanguages.Overlaps(_languages));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyAnElementRemoved()
        {
            var elementToRemove = "Java";

            var updatedLanguages = _sortedSet.RemoveElement(_languages, elementToRemove);

            Assert.IsFalse(updatedLanguages.Contains(elementToRemove));
            Assert.AreEqual(_languages.Count(), 8);
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyRemoveWhereWorks()
        {
            _languages.RemoveWhere(element => element.StartsWith("C"));

            Assert.IsFalse(_languages.Contains("C"));
            Assert.IsFalse(_languages.Contains("C++"));
            Assert.IsFalse(_languages.Contains("C#"));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyElementsReversed()
        {
            var reversedSet = _languages.Reverse();
            var firstElement = reversedSet.First();
            var lastElement = reversedSet.Last();

            Assert.IsInstanceOfType(reversedSet, typeof(IEnumerable<string>));
            Assert.AreEqual(firstElement, "TypeScript");
            Assert.AreEqual(lastElement, "C");
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyAllElementsCleared()
        {
            _languages.Clear();

            Assert.AreEqual(0, _languages.Count());
            Assert.IsNull(_languages.FirstOrDefault());
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyAllElementsCopied()
        {
            var languagesArray = new string[9];

            _languages.CopyTo(languagesArray);

            Assert.AreEqual(languagesArray.Count(), 9);
            Assert.AreEqual(languagesArray[0], "C");
            Assert.AreEqual(languagesArray[8], "TypeScript");
            Assert.IsNotNull(languagesArray);
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyProperSubset()
        {
            var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };

            Assert.IsTrue(_languages.IsSubsetOf(moreLanguages));
            Assert.IsTrue(_languages.IsProperSubsetOf(moreLanguages));
            Assert.IsTrue(moreLanguages.IsSupersetOf(_languages));
            Assert.IsTrue(moreLanguages.IsProperSupersetOf(_languages));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyUnionWithSuccessful()
        {
            var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.UnionWith(moreLanguages);

            Assert.AreEqual(_languages.Count(), 14);
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyIntersectWithSuccessful()
        {
            var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.IntersectWith(moreLanguages);

            Assert.AreEqual(_languages.Count(), 5);
            Assert.IsTrue(_languages.Contains("C"));
            Assert.IsTrue(_languages.Contains("C++"));
            Assert.IsTrue(_languages.Contains("C#"));
            Assert.IsTrue(_languages.Contains("Java"));
            Assert.IsTrue(_languages.Contains("Scala"));
            Assert.IsFalse(_languages.Contains("Assembly"));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_ExceptWithSuccessful()
        {
            var moreLanguages = new SortedSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.ExceptWith(moreLanguages);

            Assert.AreEqual(_languages.Count(), 4);
            Assert.IsTrue(_languages.Contains("TypeScript"));
            Assert.IsTrue(_languages.Contains("Python"));
            Assert.IsTrue(_languages.Contains("JavaScript"));
            Assert.IsTrue(_languages.Contains("Rust"));
            Assert.IsFalse(_languages.Contains("Assembly"));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifySetEqualsSuccessful()
        {
            var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };
            var languagesCopy = _languages;

            Assert.IsFalse(_languages.SetEquals(moreLanguages));
            Assert.IsTrue(_languages.SetEquals(languagesCopy));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifySymmetricExceptWithSuccessful()
        {
            var moreLanguages = new SortedSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.SymmetricExceptWith(moreLanguages);

            Assert.AreEqual(_languages.Count(), 14);
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_TryToGetValue()
        {
            Assert.IsTrue(_languages.TryGetValue("C#", out _));
            Assert.IsTrue(_languages.Contains("C#"));
            Assert.IsFalse(_languages.TryGetValue("Assembly", out _));
            Assert.IsFalse(_languages.Contains("Assembly"));
        }
    }
}