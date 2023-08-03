
namespace ActionAndFuncDelegates
{
    public class OrderService
    {
        public delegate void NotificationAction();
        public delegate OrderDetails FuncGetOrderDetails<in order, out OrderDetails>(Order order);
        public List<Order> OrderRepo { get; set; } = new List<Order>();

        public void CreateOrder(Order order, NotificationAction notifyAction)
        {
            // Create order
            OrderRepo.Add(order);

            // Call the notification action
            notifyAction();
        }

        public OrderDetails GetOrder(int id, FuncGetOrderDetails<Order, OrderDetails> getDetails)
        {
            // Get the order
            Order? order = OrderRepo.Find(x => x.Id == id);

            //call the Func delegate method
            OrderDetails details = getDetails(order);

            return details;
        }


    }
}
