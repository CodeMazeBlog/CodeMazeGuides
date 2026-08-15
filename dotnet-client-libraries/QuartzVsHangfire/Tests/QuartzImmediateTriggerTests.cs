using QuartzVsHangfire.QuartzSample;

namespace Tests;

public class QuartzImmediateTriggerTests
{
    [Fact]
    public void WhenBuildImmediateTrigger_ThenTriggerHasTheWelcomeEmailIdentity()
    {
        var trigger = QuartzTriggerScheduler.BuildImmediateTrigger();

        Assert.Equal("welcome-email", trigger.Key.Name);
    }
}
