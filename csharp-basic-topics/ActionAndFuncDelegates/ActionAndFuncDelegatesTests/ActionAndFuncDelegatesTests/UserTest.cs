using ActionAndFuncDelegates;
using Moq;

namespace ActionAndFuncDelegatesTests
{
    public class UserTest
    {
        public Mock<IBillingService> _billingService;

        [SetUp]
        public void Setup()
        {
            _billingService = new Mock<IBillingService>();
        }

        [Test]
        public void GivenNoSubscribers_WhenUserDetailsAreUpdatedButThereAreNoSubscribers_ThenSubscribersAreNotNotified()
        {
            var user = new User();

            user.UpdateUserDetails("John", "Smith");

            _billingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void GivenSingleSubscriber_WhenUserDetailsAreUpdated_ThenSubscriberIsNotified()
        {
            var user = new User();
            user.RegisterListener(_billingService.Object.UpdateBillingUserDetails);

            user.UpdateUserDetails("John", "Smith");

            _billingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GivenSingleSubscriber_WhenUserDetailsAreNotUpdated_ThenSubscriberIsNotNotified()
        {
            var user = new User();
            user.RegisterListener(_billingService.Object.UpdateBillingUserDetails);

            _billingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }        

        [Test]
        public void GivenMultipleSubscribers_WhenUserDetailsAreUpdated_ThenSubscribersAreNotified()
        {
            var user = new User();
            var secondBillingService = new Mock<IBillingService>();

            user.RegisterListener(_billingService.Object.UpdateBillingUserDetails);
            user.RegisterListener(secondBillingService.Object.UpdateBillingUserDetails);

            user.UpdateUserDetails("John", "Smith");

            _billingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            secondBillingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GivenMultipleSubscribers_WhenUserDetailsAreNotUpdated_ThenSubscribersAreNotified()
        {
            var user = new User();
            var secondBillingService = new Mock<IBillingService>();

            user.RegisterListener(_billingService.Object.UpdateBillingUserDetails);
            user.RegisterListener(secondBillingService.Object.UpdateBillingUserDetails);

            _billingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            secondBillingService.Verify(b => b.UpdateBillingUserDetails(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }
    }
}