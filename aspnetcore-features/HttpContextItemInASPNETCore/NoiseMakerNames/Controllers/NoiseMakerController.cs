using Microsoft.AspNetCore.Mvc;

namespace NoiseMakerNames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiseMakerController : ControllerBase
    {
        [HttpPost("add-noisemaker")]
        public IActionResult AddNoiseMaker([FromBody] NoiseMaker noiseMaker)
        {
            NamesOfNoiseMakers list = new NamesOfNoiseMakers();

            HttpContext.Items[list] = list.ViewNoiseMakers();

            if (noiseMaker.Name == "Penny")
            {
                return Ok(HttpContext.Items[list]);
            }

            list.AddNoiseMaker(noiseMaker);
            return Ok(noiseMaker);
        }
    }
}
