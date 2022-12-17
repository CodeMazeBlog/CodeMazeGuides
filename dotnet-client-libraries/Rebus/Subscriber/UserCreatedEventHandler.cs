using Rebus.Handlers;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber;
public class UserCreatedEventHandler : IHandleMessages<UserCreatedEvent>
{
    public async Task Handle(UserCreatedEvent message)
    {
        Console.WriteLine($"{nameof(UserCreatedEvent)} received. Username: {message.UserName}");
    }
}
