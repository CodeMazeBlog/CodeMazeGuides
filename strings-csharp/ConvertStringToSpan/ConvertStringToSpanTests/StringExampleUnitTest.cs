using ConvertStringToSpan;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConvertStringToSpanTests
{
    [TestClass]
    public class StringExampleUnitTest
    {
        [TestMethod]
        public void ConvertStringToSpanUsingMemoryMarshal_ShouldReturnSpan()
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
        public unsafe void ConvertStringToSpanUsingUnsafe_ShouldReturnSpan()
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
        public void ConvertStringToSpanUsingAsSpan_ShouldReturnSpan()
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
        public void ConvertStringToReadOnlySpanUsingAsSpan_ShouldReturnSpan()
        {
            // Arrange
            var myString = "Hello, World!";

            // Act
            var span = StringExample.ConvertStringToReadOnlySpanUsingAsSpan(myString);

            // Assert
            Assert.AreEqual(myString.Length, span.Length);
            Assert.AreEqual(myString, span.ToString());
        }
    }
}
