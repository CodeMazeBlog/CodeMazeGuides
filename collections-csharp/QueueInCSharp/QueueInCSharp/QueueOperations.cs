using QueueInCSharp.Models;

namespace QueueInCSharp;

public static class QueueOperations
{
    //declare a queue of orders
    public static Queue<Order> Orders;

    static QueueOperations()
    {
        //initialize the queue
        Orders = new Queue<Order>();

        //create order objects
        var order1 = new Order("Ana", new string[] { "Chockolate", "Coffee" }, 20);
        var order2 = new Order("George", new string[] { "Juice", "Sandwich" }, 15);
        var order3 = new Order("Bob", new string[] { "Ice cream" }, 5);

        //add orders to the queue
        Orders.Enqueue(order1);
        Orders.Enqueue(order2);
        Orders.Enqueue(order3);
    }

    public static int OrdersCount()
    {
        return Orders.Count;
    }

    public static (Order order, int numberOfRemainingOrders) GetOrderWithoutRemoving()
    {
        //get the first element from the queue
        var order = Orders.Peek();
        var numberOfRemainingOrders = Orders.Count();
        return (order, numberOfRemainingOrders);
    }

    public static (Order order, int numberOfRemainingOrders) GetOrderAndRemove()
    {
        //get and remove the first element from the queue
        var order = Orders.Dequeue();
        var numberOfRemainingOrders = Orders.Count();
        return (order, numberOfRemainingOrders);
    }


    public static int RemoveAllElements()
    {
        Queue<Order> orders = new Queue<Order>();

        //create order objects
        var Order1 = new Order("Ana", new string[] { "Chockolate", "Coffee" }, 20);
        var Order2 = new Order("George", new string[] { "Juice", "Sandwich" }, 15);
        var Order3 = new Order("Bob", new string[] { "Ice cream" }, 5);

        //add orders to the queue
        orders.Enqueue(Order1);
        orders.Enqueue(Order2);
        orders.Enqueue(Order3);

        //remove all elements from the queue
        orders.Clear();
        return orders.Count();
    }


}

