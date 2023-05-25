
namespace func.entities
{
    public class Account
    {
        public decimal savings { get; set; } = 1000;

        public Account(decimal valueOne, decimal valueTwo)
        {
            Action<decimal, decimal> action = Withdraws;
            action(valueOne, valueTwo);
        }
        private void Withdraws(decimal valueOne, decimal valueTwo)
        {
             this.savings -= valueOne;
             this.savings -= valueTwo;
        }
    }
}
