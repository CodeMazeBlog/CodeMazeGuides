namespace ActionAndFuncDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var user = new User();
            var billingService = new BillingService();

            user.RegisterListener(billingService.UpdateBillingUserDetails);

            user.UpdateUserDetails("John", "Smith");
        }
    }
}
