using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegates.DTO
{
    public class Order
    {
        public Customer Customer { get; set; }
        public double TotalAmount { get; set; }
    }
}
