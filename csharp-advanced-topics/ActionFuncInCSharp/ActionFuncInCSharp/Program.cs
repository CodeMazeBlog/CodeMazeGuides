using ActionFuncInCSharp;

Action<string> emailAction = (msg) => Console.WriteLine("Sending email: " + msg);
Action<string> smsAction = (msg) => Console.WriteLine("Sending SMS: " + msg);
Action<string> pushAction = (msg) => Console.WriteLine("Sending push notification: " + msg);

NotifierAction.SendNotification("Hello, user!", emailAction);
NotifierAction.SendNotification("Important update!", smsAction);
NotifierAction.SendNotification("New content available!", pushAction);

Func<string, string> basicProcessFunc = (data) => $"Basic processing: {data}";
Func<string, string> advancedProcessFunc = (data) => $"Advanced processing: {data}";

string result1 = DataProcessorFunc.ProcessData("Sample data", basicProcessFunc);
string result2 = DataProcessorFunc.ProcessData("Sample data", advancedProcessFunc);

Console.WriteLine(result1);
Console.WriteLine(result2);
