using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace MandatoryQueryStringParameters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery]QueryParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(new[] { parameters.id , parameters.number });
        }

        [HttpGet("/withparams")]
        public IActionResult GetWithSingleParameters([Required] int id, [BindRequired] int number, int check)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(new[] { id, number, check });
        }
    }
}