using CompareByteArraysInCsharp;
using System;
using System.Globalization;

namespace CompareByteArraysInCsharpTests
{
    [TestClass]
    public class CompareByteArraysUnitTests
    {
        private readonly CompareByteArrays _compareByteArrays;
        private readonly byte[] _firstArray;
        private readonly byte[] _secondArray;
        private readonly byte[] _thirdArray;

        public CompareByteArraysUnitTests() 
        {
            _compareByteArrays = new CompareByteArrays();
            _firstArray = new byte[] { 0, 1, 2, 3, 4 };
            _secondArray = new byte[] { 0, 1, 2, 3, 4 };
            _thirdArray = new byte[] { 0, 1, 2, 3, 4, 5 };
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingSequenceEqual_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingSequenceEqual(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingSequenceEqual(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingForLoop_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingForLoop(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingForLoop(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingBinaryEquality_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingBinaryEquality(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingBinaryEquality(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingHash_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingHash(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingHash(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingExcept_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingExcept(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingExcept(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingHashSet_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingHashSet(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingHashSet(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingIStructuralEquatable_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingIStructuralEquatable(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingIStructuralEquatable(_firstArray, _thirdArray));
        }

        [TestMethod]
        public void GivenByteArrays_WhenComparedUsingPInvoke_VerifyAccurateResults()
        {
            Assert.IsTrue(_compareByteArrays.CompareUsingPInvoke(_firstArray, _secondArray));
            Assert.IsFalse(_compareByteArrays.CompareUsingPInvoke(_firstArray, _thirdArray));
        }
    }
}