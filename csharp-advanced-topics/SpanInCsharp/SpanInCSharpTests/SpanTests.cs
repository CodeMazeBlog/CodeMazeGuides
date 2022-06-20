using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SpanInCSharpTests
{
    [TestClass]
    public class SpanTests
    {
        [TestMethod]
        public void WhenImplicitlyCastingStringToSpan_ThenSpanIsCreatedSuccessfully()
        {
            var str = "this is a string!";

            ReadOnlySpan<char> strSpan = str;

            Assert.AreEqual(str[0], strSpan[0]);
            Assert.AreEqual(str[1], strSpan[1]);
            Assert.AreEqual(str[2], strSpan[2]);
            Assert.AreEqual(str.Length, strSpan.Length);
        }

        [TestMethod]
        public void WhenExplicitlyCastingStringToSpan_ThenSpanIsCreatedSuccessfully()
        {
            var str = "this is a string!";

            ReadOnlySpan<char> strSpan = str.AsSpan();

            Assert.AreEqual(str[0], strSpan[0]);
            Assert.AreEqual(str[1], strSpan[1]);
            Assert.AreEqual(str[2], strSpan[2]);
            Assert.AreEqual(str.Length, strSpan.Length);
        }

        [TestMethod]
        public void WhenImplicitlyCastingArrayToSpan_ThenSpanIsCreatedSuccessfully()
        {
            int[] arr = new[] { 0, 1, 2, 3 };

            Span<int> strSpan = arr;

            Assert.AreEqual(arr[0], strSpan[0]);
            Assert.AreEqual(arr[1], strSpan[1]);
            Assert.AreEqual(arr[2], strSpan[2]);
            Assert.AreEqual(arr.Length, strSpan.Length);
        }

        [TestMethod]
        public void WhenExplicitlyCastingArrayToSpan_ThenSpanIsCreatedSuccessfully()
        {
            int[] arr = new[] { 0, 1, 2, 3 };

            Span<int> strSpan = arr.AsSpan();

            Assert.AreEqual(arr[0], strSpan[0]);
            Assert.AreEqual(arr[1], strSpan[1]);
            Assert.AreEqual(arr[2], strSpan[2]);
            Assert.AreEqual(arr.Length, strSpan.Length);
        }

        [TestMethod]
        public void WhenSlicingSpan_ThenSpanIsSlicedCorrectly()
        {
            int[] arr = new[] { 0, 1, 2, 3 };

            Span<int> strSpan = arr.AsSpan().Slice(1, 3);

            Assert.AreEqual(arr[1], strSpan[0]);
            Assert.AreEqual(arr[2], strSpan[1]);
            Assert.AreEqual(arr[3], strSpan[2]);
            Assert.AreEqual(arr.Length - 1, strSpan.Length);
        }
    }
}