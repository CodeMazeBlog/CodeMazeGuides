namespace ActionInCsharp;

public class Order
{
    public OrderStatus Status { get; private set; } = OrderStatus.Unknown;

    public void SetStatus(OrderStatus status, Action<OrderStatus> onStatusChanged)
    {
        if (Status != status)
        {
            Status = status;

            onStatusChanged(status);
        }
    }
}
