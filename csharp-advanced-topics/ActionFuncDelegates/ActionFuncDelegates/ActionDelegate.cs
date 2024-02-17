namespace ActionFuncDelegates
{
    public static class ActionDelegate
    {
        public static void Run()
        {
            Console.WriteLine("Action Delegate");

            var customers = new Dictionary<string, int>();

            customers.Add("Platinum", 25);
            customers.Add("Gold", 15);
            customers.Add("Silver", 5);

            foreach (var customer in customers)
            {
                GetBenefit(PrintDiscount, customer.Value, customer.Key);
            }
        }

        public static void GetBenefit(Action<int, string> benefit, int amount, string customer)
        {
            amount += 3;

            benefit(amount, customer);
        }

        public static void PrintDiscount(int amount, string custumer)
        {
            Console.WriteLine($"Customers {custumer} get {amount}% Discount");
        }
    }
}