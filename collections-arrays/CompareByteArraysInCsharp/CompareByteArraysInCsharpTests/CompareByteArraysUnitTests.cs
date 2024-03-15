using CompareByteArraysInCsharp;

namespace CompareByteArraysInCsharpTests
{
    [TestClass]
    public class CompareByteArraysUnitTests
    {
        private readonly CompareByteArrays _compareByteArrays;
        private readonly byte[] _firstArray;
        private readonly byte[] _secondArray;
        private readonly byte[] _thirdArray;
        private readonly string _arrayName;

        public CompareByteArraysUnitTests() 
        {
            _compareByteArrays = new CompareByteArrays();
            _firstArray = new byte[] { 0, 1, 2, 3, 4 };
            _secondArray = new byte[] { 0, 1, 2, 3, 4 };
            _thirdArray = new byte[] { 0, 1, 2, 3, 5 };
            _arrayName = string.Empty;
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingSequenceEqual_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingSequenceEqual(_firstArray, _secondArray, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingSequenceEqual(_firstArray, _thirdArray, _arrayName));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingForLoop_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingForLoop(_firstArray, _secondArray, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingForLoop(_firstArray, _thirdArray, _arrayName));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingBinaryEquality_VerifyAccurateResults()
        {
            var (first, second, third) = _compareByteArrays.GenerateTestArrays();

            Assert.IsTrue(_compareByteArrays.CompareUsingBinaryEquality(first, first, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingBinaryEquality(first, second, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingBinaryEquality(first, third, _arrayName));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingExcept_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingExcept(_firstArray, _secondArray, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingExcept(_firstArray, _thirdArray, _arrayName));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingIStructuralEquatable_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingIStructuralEquatable(_firstArray, _secondArray, _arrayName));
            Assert.IsFalse(_compareByteArrays.CompareUsingIStructuralEquatable(_firstArray, _thirdArray, _arrayName));
        }
    }
}