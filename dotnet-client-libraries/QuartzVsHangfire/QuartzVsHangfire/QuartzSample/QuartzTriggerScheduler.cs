using Quartz;

namespace QuartzVsHangfire.QuartzSample;

// Quartz.NET is built around the trigger. The schedule itself is the unit of
// work: we describe when a job fires and Quartz.NET owns the firing.
public static class QuartzTriggerScheduler
{
    // Quartz.NET: the trigger is the unit of work
    public static ITrigger BuildNightlyTrigger() =>
        TriggerBuilder.Create()
            .WithIdentity("nightly")
            .WithCronSchedule("0 0 2 * * ?")
            .Build();

    // Quartz.NET has no fire-and-forget queue. The closest equivalent is a
    // trigger that starts immediately instead of firing on a schedule.
    public static ITrigger BuildImmediateTrigger() =>
        TriggerBuilder.Create()
            .WithIdentity("welcome-email")
            .StartNow()
            .Build();
}
