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
           
            string message = sb.ToString();
          
        };

        // Invoke the Action delegate
        printMessage();

        // Event handler example
        button.Click += () =>
        {
            string message = "Button clicked!";
            
        };

        // Utility method example
        void LogMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(message);
            
            string logMessage = sb.ToString();
            
        }

        Action logAction = () => LogMessage("Log message from Action delegate");
        logAction.Invoke(); 


    }
}
