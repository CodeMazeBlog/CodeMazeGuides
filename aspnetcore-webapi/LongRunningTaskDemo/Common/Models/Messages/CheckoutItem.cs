using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.Messages
{
    public class CheckoutItem
    {
        public Guid OrderId { get; set; }

        public CheckoutRequest? Request { get; set; }
    }
}
