using HowToCallSignalRAspDotNet.HubConfig;
using HowToCallSignalRAspDotNet.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HowToCallSignalRAspDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomizerWithNonGenericHubController : ControllerBase
    {
        private readonly IHubContext<RandomizerHub> _hub;
        private readonly TimerManager _timer;

        public RandomizerWithNonGenericHubController(IHubContext<RandomizerHub> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        [HttpGet("SendRandomNumber")]
        public ActionResult<int> SendRandomNumber()
        {
            var randomValue = new Random().Next(1, 51) * 2;

            if (!_timer.IsTimerStarted)
            {
                _timer.PrepareTimer(() =>
                    _hub.Clients.All
                        .SendCoreAsync("SendClientRandomEvenNumber", [randomValue]));
            }                

            return Ok(randomValue);
        }
    }
}
