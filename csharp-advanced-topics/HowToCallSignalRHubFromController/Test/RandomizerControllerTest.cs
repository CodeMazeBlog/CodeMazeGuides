
using HowToCallSignalRHubFromController.Controllers;
using HowToCallSignalRHubFromController.HubConfig;
using HowToCallSignalRHubFromController.Models;
using HowToCallSignalRHubFromController.TimerFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Moq;

namespace Test
{
    public class Test
    {
        private RandomizerController _randomizerController;        
        
        public Test()
        {
            var timerManager = new TimerManager();

            var hub = new Mock<IHubContext<RandomizerHub, IRandomizerClient>>();
            
            _randomizerController = new(hub.Object, timerManager);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnActionResult ()
        {
            //Act
            var result = _randomizerController.SendRandomNumber();

            //Assert
            Assert.IsAssignableFrom<ActionResult<int>>(result);
        }

        [Fact]
        public void WhenSendRandomNumber_ThenReturnInt()
        {
            //Act
            var result = _randomizerController.SendRandomNumber();            

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.IsType<int>(okResult.Value);            
        }
    }
}