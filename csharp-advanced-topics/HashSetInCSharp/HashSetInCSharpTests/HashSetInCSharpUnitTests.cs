using HashSetInCSharp;

namespace HashSetInCSharpTests
{
    [TestClass]
    public class HashSetInCSharpUnitTests
    {
        HashSetsInCSharpMethods hashSet = new HashSetsInCSharpMethods();
        private readonly  HashSet<string> _languages;

        public HashSetInCSharpUnitTests()
        {
            _languages = hashSet.ProgrammingLanguages();
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyCountAndContains()
        {
            Assert.IsInstanceOfType(_languages, typeof(HashSet<string>));
            Assert.AreEqual(_languages.Count(), 9);
            Assert.IsTrue(_languages.Contains("C#"));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyHasNoDuplicates()
        {
            _languages.Add("C");
            _languages.Add("C++");
            _languages.Add("C#");
           
            Assert.IsInstanceOfType(_languages, typeof(HashSet<string>));
            Assert.AreEqual(_languages.Count(), 9);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyAnElementRemoved()
        {
            var elementToRemove = "Java";

            var updatedLanguages = hashSet.RemoveElement(_languages, elementToRemove);

            Assert.IsFalse(updatedLanguages.Contains(elementToRemove));
            Assert.AreEqual(_languages.Count(), 8);
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
            _languages.Clear();

            Assert.AreEqual(0, _languages.Count());
            Assert.IsNull(_languages.FirstOrDefault());
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyListPopulated()
        {
            var numbers = hashSet.RandomInts(100);

            var numbersList = hashSet.CreateList(numbers);

            CollectionAssert.AllItemsAreInstancesOfType(numbersList, typeof(int));
            Assert.AreEqual(numbersList.Count(), numbers.Count());
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyProperSubset()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "TypeScript", "Python", "JavaScript", "Rust", "Assembly", "Pascal" };

            Assert.IsTrue(_languages.IsSubsetOf(moreLanguages));
            Assert.IsTrue(_languages.IsProperSubsetOf(moreLanguages));
            Assert.IsTrue(moreLanguages.IsSupersetOf(_languages));
            Assert.IsTrue(moreLanguages.IsProperSupersetOf(_languages));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyUnionWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.UnionWith(moreLanguages);
            Assert.AreEqual(_languages.Count(), 14);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyIntersectWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

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
        public void GivenAHashSet_WhenNotEmpty_ExceptWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "C", "C++", "C#", "Java", "Scala", "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.ExceptWith(moreLanguages);

            Assert.AreEqual(_languages.Count(), 4);
            Assert.IsTrue(_languages.Contains("TypeScript"));
            Assert.IsTrue(_languages.Contains("Python"));
            Assert.IsTrue(_languages.Contains("JavaScript"));
            Assert.IsTrue(_languages.Contains("Rust"));
            Assert.IsFalse(_languages.Contains("Assembly"));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifySymmetricExceptWithSuccessful()
        {
            var moreLanguages = new HashSet<string> { "Assembly", "Pascal", "HTML", "CSS", "PHP" };

            _languages.SymmetricExceptWith(moreLanguages);
            
            Assert.AreEqual(_languages.Count(), 14);
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_TryToGetValue()
        {
            Assert.IsTrue(_languages.TryGetValue("C#", out _));
            Assert.IsTrue(_languages.Contains("C#"));
            Assert.IsFalse(_languages.TryGetValue("Assembly", out _));
            Assert.IsFalse(_languages.Contains("Assembly"));
        }
    }
}