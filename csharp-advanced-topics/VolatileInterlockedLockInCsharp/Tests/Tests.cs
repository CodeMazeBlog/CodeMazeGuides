using VolatileInterlockedLockInCsharp;

namespace Tests
{
    public class Tests
    {
        private void WithdrawBalance(Action<int> withdrawalAction)
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

        [Fact]
        public void GivenBalanceWithoutSync_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
        {
            var account = new Account
            {
                Balance = 100000
            };

            WithdrawBalance(account.Withdraw);

            Assert.NotEqual(100000, account.Balance);
        }

        [Fact]
        public void GivenBalanceVolatile_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
        {
            var account = new Account
            {
                BalanceVolatile = 100000
            };

            WithdrawBalance(account.WithdrawVolatile);

            Assert.NotEqual(1000, account.BalanceVolatile);
        }

        [Fact]
        public void GivenBalanceWithLock_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceLock = 100000
            };

            WithdrawBalance(account.WithdrawLock);

            Assert.Equal(0, account.BalanceLock);
        }

        [Fact]
        public void GivenBalanceWithInterlocked_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceInterlocked = 100000
            };

            WithdrawBalance(account.WithdrawInterlocked);

            Assert.Equal(0, account.BalanceInterlocked);
        }
    }
}