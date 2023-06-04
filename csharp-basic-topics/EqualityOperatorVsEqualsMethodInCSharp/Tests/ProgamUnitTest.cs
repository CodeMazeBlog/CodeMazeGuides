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
            public void GivenValueTypes_WhenBehaviorForValueTypesInvoked_ThenExpectCorrectResults()
            {
                // Arrange

                // Act
                Program.BehaviorForValueTypes();

                // Assert
                // No specific assertions as the behavior is checked internally
            }

            [TestMethod]
            public void GivenReferenceTypes_WhenBehaviorForReferenceTypesInvoked_ThenExpectCorrectResults()
            {
                // Arrange

                // Act
                Program.BehaviorForReferenceTypes();

                // Assert
                // No specific assertions as the behavior is checked internally
            }

            [TestMethod]
            public void GivenUserDefinedTypes_WhenBehaviorForUserDefinedTypesInvoked_ThenExpectCorrectResults()
            {
                // Arrange

                // Act
                Program.BehaviorForUserDefinedTypes();

                // Assert
                // No specific assertions as the behavior is checked internally
            }

            [TestMethod]
            public void GivenNullableTypes_WhenBehaviorForNullableTypesInvoked_ThenExpectCorrectResults()
            {
                // Arrange

                // Act
                Program.BehaviorForNullableTypes();

                // Assert
                // No specific assertions as the behavior is checked internally
            }
        }
    }
}