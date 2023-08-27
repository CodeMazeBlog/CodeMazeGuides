using VolatileInterlockedLockInCsharp;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void GivenBalanceWithoutSync_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
        {
            var account = new Account
            {
                Balance = 100000
            };

            using var synch = new ManualResetEventSlim(false);

            var tasks = new Task[1000];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    synch.Wait();
                    account.Withdraw(100);
                });
            }

            synch.Set();
            Task.WaitAll(tasks);

            Assert.NotEqual(100000, account.Balance);
        }

        [Fact]
        public void GivenBalanceVolatile_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
        {
            var account = new Account
            {
                BalanceVolatile = 100000
            };

            using var synch = new ManualResetEventSlim(false);

            var tasks = new Task[1000];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    synch.Wait();
                    account.WithdrawVolatile(100);
                });
            }

            synch.Set();
            Task.WaitAll(tasks);

            Assert.NotEqual(1000, account.BalanceVolatile);
        }

        [Fact]
        public void GivenBalanceWithLock_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceLock = 100000
            };

            using var synch = new ManualResetEventSlim(false);

            var tasks = new Task[1000];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    synch.Wait();
                    account.WithdrawLock(100);
                });
            }

            synch.Set();
            Task.WaitAll(tasks);

            Assert.Equal(0, account.BalanceLock);
        }

        [Fact]
        public void GivenBalanceWithInterlocked_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceInterlocked = 100000
            };

            using var synch = new ManualResetEventSlim(false);

            var tasks = new Task[1000];

            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() =>
                {
                    synch.Wait();
                    account.WithdrawInterlocked(100);
                });
            }

            synch.Set();
            Task.WaitAll(tasks);

            Assert.Equal(0, account.BalanceInterlocked);
        }
    }
}