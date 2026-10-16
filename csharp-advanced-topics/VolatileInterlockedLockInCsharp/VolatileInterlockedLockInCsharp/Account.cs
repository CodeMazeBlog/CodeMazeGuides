namespace VolatileInterlockedLockInCsharp;

public class Account
{
    private int _balance;
    private volatile int _balanceVolatile;
    private int _balanceLock;
    private int _balanceInterlocked;
    private readonly Lock _lock = new();

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
        get => Interlocked.CompareExchange(ref _balanceInterlocked, 0, 0);
        set => Interlocked.Exchange(ref _balanceInterlocked, value);
    }

    public void Withdraw(int amount)
    {
        _balance -= amount;
    }

    public void WithdrawVolatile(int amount)
    {
        _balanceVolatile -= amount;
    }

    public void WithdrawLock(int amount)
    {
        lock (_lock)
        {
            _balanceLock -= amount;
        }
    }

    public void WithdrawInterlocked(int amount)
    {
        Interlocked.Add(ref _balanceInterlocked, -amount);
    }

    public bool WithdrawIfSufficient(int amount)
    {
        var current = Volatile.Read(ref _balanceInterlocked);

        while (current >= amount)
        {
            var actual = Interlocked.CompareExchange(ref _balanceInterlocked, current - amount, current);

            if (actual == current)
                return true;

            current = actual;
        }

        return false;
    }
}