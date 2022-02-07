using System.Collections.Generic;

namespace ActionAndFuncDelegates.Customers
{
    public class CustomerData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id=101,
                    Name="John",
                    YearsAssociatedWithCompany=2,
                    Purchases=5000
                },
                new Customer
                {
                    Id=102,
                    Name="Mary",
                    YearsAssociatedWithCompany=1,
                    Purchases=10000
                },
                new Customer
                {
                    Id=103,
                    Name="Dave",
                    YearsAssociatedWithCompany=4,
                    Purchases=3000
                },
                new Customer
                {
                    Id=104,
                    Name="Mike",
                    YearsAssociatedWithCompany=3,
                    Purchases=6000
                },
                new Customer
                {
                    Id=105,
                    Name="Veronica",
                    YearsAssociatedWithCompany=1,
                    Purchases=5000
                }
            };
        }
    }
}
