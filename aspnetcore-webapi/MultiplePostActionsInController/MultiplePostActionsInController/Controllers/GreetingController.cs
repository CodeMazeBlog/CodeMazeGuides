using Microsoft.AspNetCore.Mvc;

namespace MultiplePostActionsInController.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        [HttpPost]
        public ActionResult SayGoodMorning([FromBody] string name)
        {
            return Ok($"Good Morning {name},");
        }

        [HttpPost]
        public ActionResult SayGoodEvening([FromBody] string name)
        {
            return Ok($"Good Evening {name},");
        }

        [Route("SayGoodAfternoon")]
        [HttpPost]
        public ActionResult SayGoodAfternoon([FromBody] string name)
        {
            return Ok($"Good Afternoon {name},");
        }

        [HttpPost("SayGoodNight")]
        public ActionResult SayGoodNight([FromBody]string name)
        {
            return Ok($"Good Good Night {name},");
        }
    }
}