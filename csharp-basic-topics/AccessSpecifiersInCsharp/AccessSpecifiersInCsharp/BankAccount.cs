namespace AccessSpecifiersInCsharp
{
    public class BankAccount
    {
        private int balance;

        public int GetBalance()
        {
            return balance;
        }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
            }
        }
    }
}
