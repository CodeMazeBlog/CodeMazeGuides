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
            => Ok(new[] { parameters.Id , parameters.Number });
        

        [HttpGet("/withparams")]
        public IActionResult GetWithParameters([Required] int id, [BindRequired] int number, int check)
            => Ok(new[] { id, number, check });
    }
}