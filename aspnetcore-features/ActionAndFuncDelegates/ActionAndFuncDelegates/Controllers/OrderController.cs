using Microsoft.AspNetCore.Mvc;

namespace ActionAndFuncDelegates.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController()
        {
        }

        static OrderService orderService = new OrderService();

        [HttpPost("CreateOrder")]
        public IActionResult CreateOrder(Order order)
        {
            // Call the method that has a Action delegate
            orderService.CreateOrder(order, () => {
                // Notify interested parties  
                SendEmail();
                SendSMS();
            });
            return Ok();
        }

        [HttpGet("GetOrder")]
        public IActionResult GetOrder(int id)
        {
            PopulateCartWithDummyOrder();

            // Call the method that has a Func delegate
            OrderDetails order = orderService.GetOrder(id, orderDetails);

            // Use order and details
            return Ok(order);
        }


        private static OrderDetails orderDetails(Order order)
        {
            // Get the sum of the prices
            decimal total = order.Products.Sum(x => x.Price);
            decimal productProportion = total / order.Products.Count();

            // Apply a 5% discount to the productProportion
            decimal discount = (5M / 100M) * productProportion;

            // Return the order detail 
            OrderDetails detail = new OrderDetails { Order = order, Sum = total - discount, Discount = discount};
            return detail;
        }

        private static void SendEmail() { 
            //send an Email
        }
        public static void SendSMS() { 
            //send a SMS
        }
        private static void PopulateCartWithDummyOrder()
        {
            var product1 = new Product { Id = 1, Price = 20.4M, ProductName="Monitor"};
            var product2 = new Product { Id = 2, Price = 30.3M , ProductName="Glue"};
            var product3 = new Product { Id = 3, Price = 5, ProductName="Magnet"};
            var product4 = new Product { Id = 4, Price = 64M , ProductName="Tablet"};
            var product5 = new Product { Id = 5, Price = 3.6M , ProductName="Stool"};

            orderService.OrderRepo.Add(new Order { Id = 1, CustomerName = "James", Products= new List<Product> { product1, product2, product4 } });
            orderService.OrderRepo.Add(new Order { Id = 2, CustomerName = "Pelumi", Products = new List<Product> { product3, product5 } });
            orderService.OrderRepo.Add(new Order { Id = 3, CustomerName = "Dave", Products = new List<Product> { product1, product3, product5 } });
        }

    }
}