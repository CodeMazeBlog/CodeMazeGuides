using System;

public class Class1
{
	public Class1()
	{
        // Define an Action delegate with no parameters
        Action printMessage = () =>
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Action delegate called!");
            // Store message in a variable instead of printing it directly
            string message = sb.ToString();
            // Use the message later as needed...
        };

        // Invoke the Action delegate
        printMessage();

        // Event handler example
        button.Click += () =>
        {
            string message = "Button clicked!";
            // Store event information for later use...
        };

        // Utility method example
        void LogMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message);
            // Store log message instead of printing it directly
            string logMessage = sb.ToString();
            // Use the log message later for logging purposes...
        }

        Action logAction = () => LogMessage("Log message from Action delegate");
        logAction.Invoke(); // Invoking the delegate to store the log message


    }
}
