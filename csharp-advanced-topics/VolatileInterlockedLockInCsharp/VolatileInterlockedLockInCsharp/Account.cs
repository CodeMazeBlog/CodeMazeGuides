namespace VolatileInterlockedLockInCsharp
{
    public class Account
    {
        private int _balance;
        private volatile int _balanceVolatile;
        private int _balanceLock;
        private int _balanceInterlocked;
        private object _lock = new object();
        private readonly int _delay = new Random().Next(0, 100);

        public int Balance
        {
            get => _balance;
            set => _balance = value;
        }

        public int BalanceVolatile
        {
            get => _balanceVolatile;
            set => _balanceVolatile = value;
        }

        public int BalanceLock
        {
            get
            {
                lock (_lock)
                {
                    return _balanceLock;
                }
            }
            set
            {
                lock (_lock)
                {
                    _balanceLock = value;
                }
            }
        }

        public int BalanceInterlocked
        {
            get => _balanceInterlocked;
            set => _balanceInterlocked = value;
        }

        public void Withdraw(int amount)
        {
            Thread.Sleep(_delay);
            _balance -= amount;
        }

        public void WithdrawVolatile(int amount)
        {
            Thread.Sleep(_delay);
            _balanceVolatile -= amount;
        }

        public void WithdrawLock(int amount)
        {
            lock (_lock)
            {
                Thread.Sleep(_delay);
                _balanceLock -= amount;
            }
        }

        public void WithdrawInterlocked(int amount)
        {
            Thread.Sleep(_delay);
            Interlocked.Add(ref _balanceInterlocked, -amount);
        }
    }
}
