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
                var result = Program.ComparisonBetweenIntegers();

                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoObjects_WhenComparingObjects_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenObjects();

                Assert.AreEqual("Reference: False, Equality: False, Equals: False", result);
            }

            [TestMethod]
            public void GivenTwoStrings_WhenComparingStrings_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenStrings();

                Assert.AreEqual("Reference: True, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenAnObjectAndString_WhenComparingObjectAndString_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenObjectAndString();

                Assert.AreEqual("Reference: False, Equality: False, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoClasses_WhenComparingClasses_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenClasses();

                Assert.AreEqual("Reference: False, Equality: False, Equals: False", result);
            }

            [TestMethod]
            public void GivenTwoStructs_WhenComparingStructs_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenStructs();

                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoRecords_WhenComparingRecords_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenRecords();

                Assert.AreEqual("Reference: False, Equality: True, Equals: True", result);
            }

            [TestMethod]
            public void GivenTwoNullables_WhenComparingNullables_ThenShouldReturnExpectedResults()
            {
                var result = Program.ComparisonBetweenNullables();

                Assert.AreEqual("Reference: True, Equality: True, Equals: True", result);
            }
        }
    }
}