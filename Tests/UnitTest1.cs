using Xunit;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void WhenActionDelegatesInitializedWithoutParams_ThenDelegateInvocation()
        {
            Action actionDelegate = SayHelloToTheWorld;
            var invocationList = actionDelegate.GetInvocationList();

            Assert.Equal(1, invocationList.Length);
        }
    }
}