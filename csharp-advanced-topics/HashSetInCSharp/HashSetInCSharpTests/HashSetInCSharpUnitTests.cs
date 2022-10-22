using HashSetInCSharp;
using System.Runtime.CompilerServices;

namespace HashSetInCSharpTests
{
    [TestClass]
    public class HashSetInCSharpUnitTests
    {
        HashSetsInCSharpMethods hashSet = new HashSetsInCSharpMethods();
        private HashSet<string> languages;

        public HashSetInCSharpUnitTests()
        {
            languages = hashSet.ProgrammingLanguages();
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyCountAndContains()
        {
            Assert.IsInstanceOfType(languages, typeof(HashSet<string>));
            Assert.AreEqual(languages.Count(), 9);
            Assert.IsTrue(languages.Contains("C#"));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyHasNoDuplicates()
        {
            languages.Add("C");
            languages.Add("C++");
            languages.Add("C#");
           
            Assert.IsInstanceOfType(languages, typeof(HashSet<string>));
            Assert.AreEqual(languages.Count(), 9);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyAnElementRemoved()
        {
            var elementToRemove = "Java";

            var updatedLanguages = hashSet.RemoveElement(languages, elementToRemove);

            Assert.IsFalse(updatedLanguages.Contains(elementToRemove));
            Assert.AreEqual(languages.Count(), 8);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyNoOddElements()
        {
            var numbers = hashSet.RandomInts(100);
            var oddNumbers = new HashSet<int>();

            foreach (var item in numbers) 
            {
                if (hashSet.IsOdd(item) == true) 
                {
                    oddNumbers.Add(item);
                }
            }

            hashSet.RemoveWhereElement(numbers);
            var testValue = oddNumbers.First();
            var checkValue = hashSet.IsOdd(testValue);
            
            Assert.IsTrue(checkValue);
            Assert.IsFalse(oddNumbers.IsSubsetOf(numbers));
            Assert.AreEqual(numbers.Union(oddNumbers).Count(), 100);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyAllElementsCleared()
        {
            languages.Clear();

            Assert.AreEqual(0, languages.Count());
            Assert.IsNull(languages.FirstOrDefault());
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyListPopulated()
        {
            var numbers = hashSet.RandomInts(100);

            var numbersList = hashSet.CreateList(numbers);

            CollectionAssert.AllItemsAreInstancesOfType(numbersList, typeof(int));
            Equals(numbersList.Count(), numbers.Count());
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyProperSubset()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };

            Assert.IsTrue(languages.IsSubsetOf(moreLanguages));
            Assert.IsTrue(languages.IsProperSubsetOf(moreLanguages));
            Assert.IsTrue(moreLanguages.IsSupersetOf(languages));
            Assert.IsTrue(moreLanguages.IsProperSupersetOf(languages));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyUnionWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            languages.UnionWith(moreLanguages);
            Assert.AreEqual(languages.Count(), 14);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyIntersectWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            languages.IntersectWith(moreLanguages);

            Assert.AreEqual(languages.Count(), 5);
            Assert.IsTrue(languages.Contains("C"));
            Assert.IsTrue(languages.Contains("C++"));
            Assert.IsTrue(languages.Contains("C#"));
            Assert.IsTrue(languages.Contains("Java"));
            Assert.IsTrue(languages.Contains("Scala"));
            Assert.IsFalse(languages.Contains("Assembly"));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_ExceptWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            languages.ExceptWith(moreLanguages);

            Assert.AreEqual(languages.Count(), 4);
            Assert.IsTrue(languages.Contains("TypeScript"));
            Assert.IsTrue(languages.Contains("Python"));
            Assert.IsTrue(languages.Contains("JavaScript"));
            Assert.IsTrue(languages.Contains("Rust"));
            Assert.IsFalse(languages.Contains("Assembly"));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifySymmetricExceptWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            languages.SymmetricExceptWith(moreLanguages);
            
            Assert.AreEqual(languages.Count(), 14);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_TryToGetValue()
        {
            Assert.IsTrue(languages.TryGetValue("C#", out _));
            Assert.IsTrue(languages.Contains("C#"));
            Assert.IsFalse(languages.TryGetValue("Assembly", out _));
            Assert.IsFalse(languages.Contains("Assembly"));
        }
    }
}