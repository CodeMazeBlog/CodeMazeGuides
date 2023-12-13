using DelegateFuncAppSample;


Action displayMessageAction = DisplayMessage1;

displayMessageAction();

displayMessageAction = DisplayMessage2;

displayMessageAction();
    
static void DisplayMessage1()
{
    Console.WriteLine("This is a call from an Action Delegate 1!");
}

static void DisplayMessage2()
{
    Console.WriteLine("This is a call from an Action Delegate 2!");
}


Func<int, int, long> add = (x, y) => x + y;

var resultX = add(5, 10);

Console.WriteLine("Result: " + resultX);


retryPoint:

Console.WriteLine("Please type the csv file path: (.\\Samples\\Sample.csv)");
var file = Console.ReadLine();

if (string.IsNullOrEmpty(file))
{
    Console.WriteLine("Invalid file path!");
    goto retryPoint;
}
if (!File.Exists(file))
{
    Console.WriteLine("File does not exist!");
    goto retryPoint;
}

try
{
    Console.WriteLine("Processing...");
    var result = ProcessFile();
    Console.WriteLine(result ? "Processing completed with success." : "Fail on processesing!");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}

return;

bool ProcessFile()
{
    var notificationService = new SendNotifications();
    var procSenders = new SenderProcess();
    try
    {
        var result = procSenders.ProcessFile(file, notificationService);
        if (result == null)
        {
            Console.WriteLine("Result is null!");
        }
        else
        {
            var totalProcessed = result.CountTypes.Sum();

            Console.WriteLine($"Total WhatsApp processed: {notificationService.CountTypes[0]}");
            Console.WriteLine($"Total Sms processed: {notificationService.CountTypes[1]}");
            Console.WriteLine($"Total Email processed: {notificationService.CountTypes[2]}");
            Console.WriteLine($"Total messages processed: {totalProcessed}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error processing: {ex.Message}");
    }

    return true;
}