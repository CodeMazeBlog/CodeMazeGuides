using Hangfire;
using Hangfire.InMemory;
using Quartz;
using QuartzVsHangfire.HangfireSample;
using QuartzVsHangfire.QuartzSample;

// Hangfire needs storage because the queue is the product. An in-memory store
// keeps this comparison sample self-contained (no SQL Server or Redis required).
GlobalConfiguration.Configuration.UseInMemoryStorage();

var jobId = HangfireJobScheduler.EnqueueWelcomeEmail(userId: 42);
HangfireJobScheduler.ScheduleNightlyReport();

Console.WriteLine($"Hangfire enqueued the welcome email as job '{jobId}' and scheduled the 'nightly' report.");

// Quartz.NET needs no storage to describe a schedule: the trigger is the product.
var trigger = (ICronTrigger)QuartzTriggerScheduler.BuildNightlyTrigger();

Console.WriteLine($"Quartz.NET built trigger '{trigger.Key.Name}' with cron expression '{trigger.CronExpressionString}'.");
