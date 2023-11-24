using QueueInCSharp;

var (firstRemovedOrder, numberOfRemainingOrders) = QueueOperations.GetOrderAndRemove();
Console.WriteLine($"Dequeue the first order. Client: {firstRemovedOrder.ClientName}. Remaining orders: {numberOfRemainingOrders}");

var (firstPeekedOrder, numberOfOrders) = QueueOperations.GetOrderWithoutRemoving();
Console.WriteLine($"Peek the first order. Client: {firstPeekedOrder.ClientName}. Remaining orders: {numberOfOrders}");


