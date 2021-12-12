using QueueInCSharp;

var (firstPeekedOrder, numberOfOrders) = QueueOperations.GetOrderWithoutRemoving();
Console.WriteLine($"Peek the first order. Client: {firstPeekedOrder.ClientName}. Remaining orders: {numberOfOrders}");


var (firstRemovedOrder, numberOfRemainingOrders) = QueueOperations.GetOrderAndRemove();
Console.WriteLine($"Dequeue the first order. Client: {firstPeekedOrder.ClientName}. Remaining orders: {numberOfRemainingOrders}");


