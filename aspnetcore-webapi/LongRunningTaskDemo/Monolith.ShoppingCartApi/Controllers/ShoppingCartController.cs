using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Monolith.ShoppingCartApi.Coordinators;

namespace Monolith.ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly ICheckoutCoordinator _checkoutCoordinator;

        public ShoppingCartController(ICheckoutCoordinator checkoutCoordinator)
        {
            _checkoutCoordinator = checkoutCoordinator;
        }

        [HttpPost("checkout")]
        [ProducesResponseType(typeof(CheckoutResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Checkout(CheckoutRequest request) 
            => Ok(await _checkoutCoordinator.ProcessCheckoutAsync(request));
    }
}