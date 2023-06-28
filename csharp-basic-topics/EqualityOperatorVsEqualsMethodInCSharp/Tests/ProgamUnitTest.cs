using EqualityOperatorVsEqualsMethodInCSharp;

namespace Tests
{
    [TestClass]
    public class ProgramUnitTest
    {
        [TestClass]
        public class ProgramTests
        {
            [TestMethod]
            public void GivenTwoIntegers_WhenComparingIntegers_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenIntegers();

                // Assert
                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoObjects_WhenComparingObjects_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenObjects();

                // Assert
                Assert.AreEqual("Reference: False, Equality: False, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoStrings_WhenComparingStrings_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenStrings();

                // Assert
                Assert.AreEqual("Reference: True, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenAnObjectAndString_WhenComparingObjectAndString_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenObjectAndString();

                // Assert
                Assert.AreEqual("Reference: False, Equality: False, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoClasses_WhenComparingClasses_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenClasses();

                // Assert
                Assert.AreEqual("Reference: False, Equality: False, Equals: False", result);
            }

            [TestMethod]
            public void GivenTwoStructs_WhenComparingStructs_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenStructs();

                // Assert
                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoRecords_WhenComparingRecords_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenRecords();

                // Assert
                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoNullables_WhenComparingNullables_ThenShouldReturnExpectedResults()
            {
                // Arrange

                // Act
                var result = Program.ComparisonBetweenNullables();

                // Assert
                Assert.AreEqual("Reference: True, Equality: True, Equals: True", result);
            }
        }
    }
}