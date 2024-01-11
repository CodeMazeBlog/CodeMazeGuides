public class BankAccount
{
    private string accountNumber;
    private decimal balance;

    public string AccountNumber
    {
        get { return accountNumber; }
        set { accountNumber = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        private set { balance = value; }
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