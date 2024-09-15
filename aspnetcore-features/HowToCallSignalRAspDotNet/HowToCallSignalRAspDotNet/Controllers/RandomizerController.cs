using HowToCallSignalRAspDotNet.HubConfig;
using HowToCallSignalRAspDotNet.Models;
using HowToCallSignalRAspDotNet.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace HowToCallSignalRAspDotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomizerController : ControllerBase
    {
        private readonly IHubContext<RandomizerHub, IRandomizerClient> _hub;
        private readonly TimerManager _timer;

        public RandomizerController(IHubContext<RandomizerHub, IRandomizerClient> hub, TimerManager timer)
        {
            _hub = hub;
            _timer = timer;
        }

        [HttpGet("SendRandomNumber")]
        public ActionResult<int> SendRandomNumber()
        {
            var randomValue = Random.Shared.Next(1, 51) * 2;

            if (!_timer.IsTimerStarted)
            {
                _timer.PrepareTimer(() =>
                    _hub.Clients.All
                        .SendClientRandomEvenNumber(randomValue));
            }

            return Ok(randomValue);
        }
    }
}
