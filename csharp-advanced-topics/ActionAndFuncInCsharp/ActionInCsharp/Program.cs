using ActionInCsharp;

var order = new Order();
order.SetStatus(OrderStatus.InProgress, LogChangeStatus);

void LogChangeStatus(OrderStatus status)
{
    Console.WriteLine($"Current order status: {status}");
}
