using ConvertStringToSpan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertStringToSpanTests
{
    [TestClass]
    public class StringExampleUnitTest
    {
        private StringExample _stringExample = new();

        [TestMethod]
        public void GivenString_WhenConvertStringToCharArray_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = _stringExample.ConvertStringToSpanUsingToCharArray();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }

        [TestMethod]
        public unsafe void GivenString_WhenConvertStringToSpanUsingUnsafe_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = _stringExample.ConvertStringToSpanUsingUnsafe();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }

        [TestMethod]
        public void GivenString_WhenConvertStringToSpanUsingAsSpan_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = _stringExample.ConvertStringToSpanUsingAsSpan();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }

        [TestMethod]
        public void GivenString_WhenConvertStringToReadOnlySpanUsingAsSpan_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = _stringExample.ConvertStringToReadOnlySpanUsingAsSpan();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }

        [TestMethod]
        public void GivenString_WhenImplicitlyConvertString_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = _stringExample.ConvertStringToSpan();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }
    }
}