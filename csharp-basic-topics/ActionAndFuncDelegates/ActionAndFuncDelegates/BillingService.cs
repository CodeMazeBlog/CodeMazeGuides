namespace ActionAndFuncDelegates
{
    public class BillingService : IBillingService
    {
        public void UpdateBillingUserDetails(string name, string surname)
        {
            Console.WriteLine($"Update notification received. New user details: {name} {surname}");
        }
    }
}
