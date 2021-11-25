using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncLINQExample
{
    public class Selector
    {
        public static bool PremiumCustomerSelector(Customer customer)
        {
            if (customer.Spending > 250)
            {
                return true;
            }
            return false;
        }
    }
}
