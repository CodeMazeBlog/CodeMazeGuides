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
                Balance = 1000
            };

            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    account.Withdraw(100);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.NotEqual(1000, account.Balance);
        }

        [Fact]
        public void GivenBalanceVolatile_WhenMultipleWithdrawals_ThenFinalBalanceIsIncorrect()
        {
            var account = new Account
            {
                BalanceVolatile = 1000
            };

            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    account.WithdrawVolatile(100);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.NotEqual(1000, account.BalanceVolatile);
        }

        [Fact]
        public void GivenBalanceWithLock_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceLock = 1000
            };

            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    account.WithdrawLock(100);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.Equal(0, account.BalanceLock);
        }

        [Fact]
        public void GivenBalanceWithInterlocked_WhenMultipleWithdrawals_ThenFinalBalanceIsCorrect()
        {
            var account = new Account
            {
                BalanceInterlocked = 1000
            };

            var threads = new Thread[10];

            for (var i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    account.WithdrawInterlocked(100);
                });
                threads[i].Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Assert.Equal(0, account.BalanceInterlocked);
        }
    }
}