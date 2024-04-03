public class BankAccount
{
    public string AccountNumber { get; }
    public decimal Balance { get; private set; }

    public BankAccount(string accountNumber, decimal initialBalance = 0)
    {
        AccountNumber = accountNumber;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposit successful. New account balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount for deposit.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawal successful. New account balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Invalid amount for withdrawal or insufficient funds.");
        }
    }
}