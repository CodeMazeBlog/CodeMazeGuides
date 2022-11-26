using HashSetvsSortedSetInCSharp;

namespace HashSetvsSortedSetInCSharpTests
{
    [TestClass]
    public class HashSetvsSortedSetUnitTests
    {
        private readonly HashSet<int> _hashSet;
        private readonly SortedSet<int> _sortedSet;
        private readonly int _searchValue;
        private readonly Operations _setObject;

        public HashSetvsSortedSetUnitTests()
        {
            _setObject = new Operations();
            _hashSet = _setObject.InitializeIntHashSet();
            _sortedSet = _setObject.InitializeIntSortedSet();
            _searchValue = Int32.MaxValue - 1;
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifyCountAndContains()
        {
            Assert.IsInstanceOfType(_sortedSet, typeof(SortedSet<int>));
            Assert.IsTrue(_sortedSet.Contains(_searchValue));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifyCountAndContains()
        {
            Assert.IsInstanceOfType(_hashSet, typeof(HashSet<int>));
            Assert.IsTrue(_hashSet.Contains(_searchValue));
        }

        [TestMethod]
        public void GivenASortedSet_WhenNotEmpty_VerifySuccessfullyEnumerated()
        {
            var numList = _setObject.SortSortedSetElements();

            var firstNum = numList.First();
            var lastNum = numList.Last();
            var min = numList.Min();
            var max = numList.Max();

            Assert.IsTrue(firstNum == min);
            Assert.IsTrue(lastNum == max);
            Assert.IsInstanceOfType(numList, typeof(List<int>));
        }

        [TestMethod]
        public void GivenAHashSet_WhenNotEmpty_VerifySuccessfullyEnumerated()
        {
            var numList = _setObject.SortHashSetElements();

            var firstNum = numList.First();
            var lastNum = numList.Last();
            var min = numList.Min();
            var max = numList.Max();

            Assert.IsTrue(firstNum == min);
            Assert.IsTrue(lastNum == max);
            Assert.IsInstanceOfType(numList, typeof(List<int>));
        }
    }
}