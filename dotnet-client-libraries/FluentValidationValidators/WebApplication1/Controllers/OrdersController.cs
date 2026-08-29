using ClassLibrary1;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IValidator<Order> _validator;

        public OrdersController(IValidator<Order> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            var validationResult = await _validator.ValidateAsync(order);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return ValidationProblem(ModelState);
            }

            return Ok("Success!");
        }
    }
}
