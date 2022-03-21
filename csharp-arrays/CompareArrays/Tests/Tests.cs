using CompareArrays;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        private static readonly ArrayComparer _arrayComparer = new();
        private static readonly int[] _firstArray = new int[] { 10, 9, 3, 8, 7 };
        private static readonly int[] _secondArray = new int[] { 10, 9, 3, 8, 7 };
        
        [TestMethod]
        public void GivenTheClassProgram_WhenExecuteTheMainMethod_ThenSetTheOutPutResultToOne()
        {
            Program.Main(Array.Empty<string>());

            Assert.AreEqual(1, Program.OutPutResult);
        }

        [TestMethod]
        public void GivenTwoEqualReferenceArrays_WhenCompareThemUsingEqualityOperatorMethod_ThenReturnTrue()
        {
            var result = _arrayComparer.EqualityOperator(_firstArray, _firstArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoDifferentReferenceArrays_WhenCompareThemUsingEqualityOperatorMethod_ThenReturnFalse()
        {
            var result = _arrayComparer.EqualityOperator(_firstArray, _secondArray);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoEqualDataArrays_WhenCompareThemUsingForLoopMethodAnd_ThenReturnTrue()
        {
            var result = _arrayComparer.ForLoop(_firstArray, _secondArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoArrays_WhenCompareThemUsingForLoopMethodAndTheArraysSizeAreDifferent_ThenReturnFalse()
        {
            var result = _arrayComparer.ForLoop(_firstArray, new int[1]);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoDifferentDataArrays_WhenCompareThemUsingForLoopMethod_ThenReturnFalse()
        {
            var result = _arrayComparer.ForLoop(_firstArray, new int[5] { 2, 3, 4, 5, 7 });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoEqualDataArrays_WhenCompareThemUsingEnumerableSequenceEqualMethod_ThenReturnTrue()
        {
            var result = _arrayComparer.EnumerableSequenceEqual(_firstArray, _secondArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoEqualDataArraysOfArticle_WhenCompareThemUsingEnumerableSequeceEqualMethod_ThenReturnTrue()
        {
            var firstArticle = new Article() { Title = "How to Deserialize a Complex JSON Object in C# .NET", LastUpdate = new DateTime(2022, 03, 18) };
            var similarFirstArticle = new Article() { Title = "How to Deserialize a Complex JSON Object in C# .NET", LastUpdate = new DateTime(2022, 03, 18) };
            var secondArticle = new Article() { Title = "How to Populate an Array With the Same Value in C#", LastUpdate = new DateTime(2022, 02, 19) };
            var similarSecondArticle = new Article() { Title = "How to Populate an Array With the Same Value in C#", LastUpdate = new DateTime(2022, 02, 19) };

            var firstArray = new Article[] { firstArticle, secondArticle };
            var secondArray = new Article[] { similarFirstArticle, similarSecondArticle };

            var result = _arrayComparer.EnumerableSequenceEqual(firstArray, secondArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoDifferentReferenceArrays_WhenCompareThemUsingEnumerableEquals_ThenReturnFalse()
        {
            var result = _arrayComparer.EnumerableEquals(_firstArray, _secondArray);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoEqualReferenceArrays_WhenCompareThemUsingEnumerableEquals_ThenReturnTrue()
        {
            var result = _arrayComparer.EnumerableEquals(_firstArray, _firstArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoDifferentReferenceArrays_WhenCompareThemUsingEnumerableReferenceEquals_ThenReturnFalse()
        {
            var result = _arrayComparer.EnumerableReferenceEquals(_firstArray, _secondArray);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GivenTwoEqualReferenceArrays_WhenCompareThemUsingEnumerableReferenceEquals_ThenReturnTrue()
        {
            var result = _arrayComparer.EnumerableReferenceEquals(_firstArray, _firstArray);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenTwoEqualDataArrays_WhenCompareThemUsingStructuralEquatable_ThenReturnTrue()
        {
            var result = _arrayComparer.StructuralEquatable(_firstArray, _secondArray);

            Assert.IsTrue(result);
        }
    }
}