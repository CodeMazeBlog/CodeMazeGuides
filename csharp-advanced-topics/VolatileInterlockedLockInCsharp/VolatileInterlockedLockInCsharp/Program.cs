namespace VolatileInterlockedLockInCsharp;

internal class Program
{
    static void Main(string[] args)
    {
        var account = new Account
        {
            Balance = 100000,
            BalanceVolatile = 100000,
            BalanceLock = 100000,
            BalanceInterlocked = 100000
        };

        Console.WriteLine("Withdrawal without synchronization");
        AccountService.WithdrawBalance(account.Withdraw);
        Console.WriteLine($"Final balance: {account.Balance}");

        Console.WriteLine("Withdrawal with the 'volatile' keyword");
        AccountService.WithdrawBalance(account.WithdrawVolatile);
        Console.WriteLine($"Final balance: {account.BalanceVolatile}");

        Console.WriteLine("Withdrawal with the 'lock' statement");
        AccountService.WithdrawBalance(account.WithdrawLock);
        Console.WriteLine($"Final balance: {account.BalanceLock}");

        Console.WriteLine("Withdrawal with the 'Interlocked' class");
        AccountService.WithdrawBalance(account.WithdrawInterlocked);
        Console.WriteLine($"Final balance: {account.BalanceInterlocked}");

        var initializer = new OneShotInitializer();
        var winners = 0;

        Parallel.For(0, 1000, _ =>
        {
            if (initializer.TryStart())
                Interlocked.Increment(ref winners);
        });

        Console.WriteLine($"Calls that won the initialization: {winners}");

        var guardedAccount = new Account
        {
            BalanceInterlocked = 100000
        };
        var approved = 0;

        Parallel.For(0, 1100, _ =>
        {
            if (guardedAccount.WithdrawIfSufficient(100))
                Interlocked.Increment(ref approved);
        });

        Console.WriteLine($"Approved withdrawals: {approved} of 1100");
        Console.WriteLine($"Final balance: {guardedAccount.BalanceInterlocked}");
    }
}