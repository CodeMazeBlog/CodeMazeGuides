using HowToCallSignalRAspDotNet.Models;
using Microsoft.AspNetCore.SignalR;

namespace HowToCallSignalRAspDotNet.HubConfig
{
    public class RandomizerHub : Hub<IRandomizerClient>
    {
    }
}
