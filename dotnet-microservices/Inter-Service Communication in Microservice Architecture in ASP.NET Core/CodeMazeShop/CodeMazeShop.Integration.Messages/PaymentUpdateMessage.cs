using System;

namespace CodeMazeShop.Integration.Messages;

public class PaymentUpdateMessage
{
    public Guid OrderId { get; set; }

    public bool PaymentSuccess { get; set; }
}
