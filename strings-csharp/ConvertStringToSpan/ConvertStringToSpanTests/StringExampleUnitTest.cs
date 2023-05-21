using ConvertStringToSpan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertStringToSpanTests
{
    [TestClass]
    public class StringExampleUnitTest
    {
        private StringExample stringExample = new();
        [TestMethod]
        public void GivenString_WhenConvertStringToSpanUsingMemoryMarshal_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = stringExample.ConvertStringToSpanUsingMemoryMarshal();

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
            var span = stringExample.ConvertStringToSpanUsingUnsafe();

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
            var span = stringExample.ConvertStringToSpanUsingAsSpan();

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
            var span = stringExample.ConvertStringToReadOnlySpanUsingAsSpan();

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
            var span = stringExample.ConvertStringToSpan();

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }
    }
}