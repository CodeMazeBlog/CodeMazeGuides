using HowToCallSignalRHubFromController.Models;
using Microsoft.AspNetCore.SignalR;

namespace HowToCallSignalRHubFromController.HubConfig
{
    public class RandomizerHub : Hub<IRandomizerClient>
    {
    }
}
