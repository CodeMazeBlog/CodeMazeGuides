using ActionUsageExample;

IMessagePrintService messagePrintService = new MessagePrintService();

Action<string> messageBroker = messagePrintService.WriteToConsole;
messageBroker += messagePrintService.WriteToDebugOutput;

//
// Write message to target outputs
//
var message = "This a test message";
messageBroker.Invoke(message);

var _ = Console.ReadKey();
