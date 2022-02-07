using Xunit;
using ActionDelegateSample;

namespace Tests
{
    public class ActionTest
    {
        [Fact]
        public void WhenInvoked_ThenDisplayMessage()
        {
            var result = new Program().InvokeDisplay();

            Assert.IsType<bool>(result);
            Assert.True(result);
        }

        [Fact]
        public void WhenCreatingClass_SendNotification()
        {
            var user = new User() { Email = "test@user.com" };
            var result = user.NotifyUser();

            Assert.IsType<bool>(result);
            Assert.True(result);
        }
    }
}
