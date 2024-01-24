public class BankAccount
{
    private string _accountNumber;
    private decimal _balance;

    public BankAccount(string accountNumber, decimal balance)
    {
        _accountNumber = accountNumber;
        _balance = balance;
    }

    public string AccountNumber
    {
        get { return _accountNumber; }
        private set { _accountNumber = value; }
    }

    public decimal Balance
    {
        get { return _balance; }
        private set { _balance = value; }
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