// Define Job
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.NET;

var job = JobBuilder.Create<BackgroundJob>()
    .WithIdentity(name: "BackgroundJob", group: "JobGroup")
    .UsingJobData("ConsoleOutput", "Executing background job using JobDataMap")
    .UsingJobData("UseJobDataMapConsoleOutput", true)
    .Build();

var trigger = TriggerBuilder.Create()
    .WithIdentity(name: "SimpleRepeatingTrigger", group: "TriggerGroup")
    .WithSimpleSchedule(o => o
        .RepeatForever()
        .WithIntervalInSeconds(5))
    .Build();

var builder = Host.CreateDefaultBuilder()
    .ConfigureServices((cxt, services) =>
    {
        services.AddQuartz(opt =>
        {
            opt.UsePersistentStore(s =>
            {
                s.UseSqlServer("Server=localhost,1433;Database=Quartz;User Id=sa;Password=<CONNECTION_STRING>;Encrypt=False;");
                s.UseJsonSerializer();
            });
        });
        services.AddQuartzHostedService(opt =>
        {
            opt.WaitForJobsToComplete = true;
        });
    }).Build();

var schedulerFactory = builder.Services.GetRequiredService<ISchedulerFactory>();
var scheduler = await schedulerFactory.GetScheduler();

await scheduler.ScheduleJob(job, trigger);
await builder.RunAsync();