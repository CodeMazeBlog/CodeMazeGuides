using ConvertStringToSpan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertStringToSpanTests
{
    [TestClass]
    public class StringExampleUnitTest
    {
        [TestMethod]
        public void GivenString_WhenConvertStringToSpanUsingMemoryMarshal_ThenReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = StringExample.ConvertStringToSpanUsingMemoryMarshal(myString);

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
            var span = StringExample.ConvertStringToSpanUsingUnsafe(myString);

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
            var span = StringExample.ConvertStringToSpanUsingAsSpan(myString);

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
            var span = StringExample.ConvertStringToReadOnlySpanUsingAsSpan(myString);

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
            var span = StringExample.ConvertStringToSpan(myString);

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }

    }
}