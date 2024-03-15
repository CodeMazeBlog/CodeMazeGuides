namespace VolatileInterlockedLockInCsharp;

public static class AccountService
{
    public static void WithdrawBalance(Action<int> withdrawalAction)
    {
        using var synch = new ManualResetEventSlim(false);

        var tasks = new Task[1000];

        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                synch.Wait();
                Thread.Sleep(Random.Shared.Next(50, 300));
                withdrawalAction(100);
            });
        }

        synch.Set();
        Task.WaitAll(tasks);
    }
}
