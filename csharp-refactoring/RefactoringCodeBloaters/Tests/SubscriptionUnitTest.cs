using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringCodeBloaters.PrimitiveObsession.Correct;

namespace Tests
{
    [TestClass]
    public class SubscriptionUnitTest
    {
        [TestMethod]
        public void WhenTwoSubscriptionsAreEqual_ThenResultIsTrue()
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
        public void WhenTwoSubscriptionsAreNotEqual_ThenResultIsFalse()
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
        public void GivenFreeSubscription_WhenGettingHashCode_CorrectCodeIsReturned()
        {
            // Arrange
            var subscription = Subscription.Free;

            // Act
            var hashCode = subscription.GetHashCode();

            // Assert
            Assert.AreEqual(0, hashCode);
        }

        [TestMethod]
        public void GivenFamilySubscription_WhenGettingHashCode_CorrectCodeIsReturned()
        {
            // Arrange
            var subscription = Subscription.Family;

            // Act
            var hashCode = subscription.GetHashCode();

            // Assert
            Assert.AreEqual(1, hashCode);
        }

        [TestMethod]
        public void GivenPremiumSubscription_WhenGettingHashCode_CorrectCodeIsReturned()
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