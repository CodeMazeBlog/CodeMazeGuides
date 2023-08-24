using TaskAndValueTaskExample;

await CheckTaskStatus();

static async Task CheckTaskStatus()
{
    var task = DummyWeatherProvider.Get("Stockholm");
    LogTaskStatus(task.Status);

    await task;
    LogTaskStatus(task.Status);
}

static void LogTaskStatus(TaskStatus status)
{
    Console.WriteLine($"Task Status: {Enum.GetName(typeof(TaskStatus), status)}");
}