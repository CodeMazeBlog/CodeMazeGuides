using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class SubscriptionTests
    {
        [TestMethod]
        public void Equals_ValidInput_ReturnsTrue()
        {
            // Arrange
            var subscription1 = Subscription.Free;
            var subscription2 = Subscription.Free;

            // Act
            var result = subscription1.Equals(subscription2);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Equals_InvalidInput_ReturnsFalse()
        {
            // Arrange
            var subscription1 = Subscription.Free;
            var subscription2 = Subscription.Family;

            // Act
            var result = subscription1.Equals(subscription2);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetHashCode_FreeSubscription_ReturnsExpectedValue()
        {
            // Arrange
            var subscription = Subscription.Free;

            // Act
            var hashCode = subscription.GetHashCode();

            // Assert
            Assert.AreEqual(0, hashCode);
        }

        [TestMethod]
        public void GetHashCode_FamilySubscription_ReturnsExpectedValue()
        {
            // Arrange
            var subscription = Subscription.Family;

            // Act
            var hashCode = subscription.GetHashCode();

            // Assert
            Assert.AreEqual(1, hashCode);
        }

        [TestMethod]
        public void GetHashCode_PremiumSubscription_ReturnsExpectedValue()
        {
            // Arrange
            var subscription = Subscription.Premium;

            // Act
            var hashCode = subscription.GetHashCode();

            // Assert
            Assert.AreEqual(2, hashCode);
        }
    }
}