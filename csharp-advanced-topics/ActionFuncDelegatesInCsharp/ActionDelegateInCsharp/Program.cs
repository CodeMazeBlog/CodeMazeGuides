// Create a new Logger object.
var logger = new Logger();

// Create an Action delegate that logs a message to the console.
Action<string> logMessageDelegate = (message) => Console.WriteLine(message);

// Log a message.
logger.LogMessage("Action Delegates!", logMessageDelegate);