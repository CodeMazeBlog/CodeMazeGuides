using Microsoft.AspNetCore.Mvc;

namespace SecretMgt.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly PaymentService _orderService;

        public OrderController(PaymentService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public IActionResult InitializePayement(int orderId, string email)
        {
            var response = _orderService.PayViaPaystack(orderId, email);

            return Ok(response.Data.AuthorizationUrl);
        }
    }
}
