using Microsoft.AspNetCore.Mvc;

namespace FifthGradeNoiseMakers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoiseMakersController : ControllerBase
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
