using Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICheckoutProcessor _checkoutProcessor;

        public ShoppingCartController(ICheckoutProcessor checkoutProcessor)
        {
            _checkoutProcessor = checkoutProcessor;
        }

        [HttpPost("checkout")]
        [ProducesResponseType(typeof(CheckoutResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Checkout(CheckoutRequest request) => Ok(await _checkoutProcessor.ProcessCheckoutAsync(request));
    }
}
