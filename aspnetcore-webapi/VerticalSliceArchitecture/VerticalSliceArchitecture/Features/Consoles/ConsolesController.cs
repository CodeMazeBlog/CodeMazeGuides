using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VerticalSliceArchitecture.Features.Consoles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConsolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAllConsoles.ConsoleResult>>> GetConsolesAsync()
        {
            var result = await _mediator.Send(new GetAllConsoles.GetConsolesQuery());

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
