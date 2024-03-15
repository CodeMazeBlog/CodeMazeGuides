namespace AccessModifiersInCsharp
{
    public class BankAccount
    {
        private int _balance;

        public int GetBalance()
        {
            return _balance;
        }

        public void Deposit(int amount)
        {
            _balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (_balance - amount >= 0)
            {
                _balance -= amount;
            }
        }
    }
}
