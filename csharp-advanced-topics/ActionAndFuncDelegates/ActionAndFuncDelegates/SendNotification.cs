using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegates;

public class SendNotification
{
    public Action<string, string> SendNotificationAction = (recipient, message) =>
    {
        Console.WriteLine($"Sending a notification to {recipient}: {message}");
    };

}
