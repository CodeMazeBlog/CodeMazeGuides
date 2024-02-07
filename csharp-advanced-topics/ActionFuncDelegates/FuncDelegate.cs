namespace ActionFuncDelegates
{
    public static class FuncDelegate
    {
        public static void Run()
        {
            Console.WriteLine("Func Delegate");

            var customers = new Dictionary<string, int>();

            customers.Add("Platinum", 25);
            customers.Add("Gold", 15);
            customers.Add("Silver", 5);

            foreach (var customer in customers)
            {
                GetBenefit(AddDiscount, customer.Value, customer.Key);
            }

        }

        public static void GetBenefit(Func<int, int> benefit, int amount, string customer)
        {
            var updatedAmount = benefit(amount);
            Console.WriteLine($"Customers {customer} get {updatedAmount}% Discount");
        }

        public static int AddDiscount(int amount)
        {
            return amount = +amount * 2;
        }
    }
}
