using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.Messages
{
    public class PaymentSuccess : CheckoutItem
    {
        public int Amount { get; set; }
    }
}
