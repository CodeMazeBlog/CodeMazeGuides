namespace VolatileInterlockedLockInCsharp;

public static class AccountService
{
    public static void WithdrawBalance(Action<int> withdrawalAction)
    {
        using var synch = new ManualResetEventSlim(false);

        var tasks = new Task[10];

        for (var i = 0; i < tasks.Length; i++)
        {
            tasks[i] = Task.Run(() =>
            {
                synch.Wait();

                for (var j = 0; j < 100; j++)
                    withdrawalAction(100);
            });
        }

        synch.Set();
        Task.WaitAll(tasks);
    }
}
