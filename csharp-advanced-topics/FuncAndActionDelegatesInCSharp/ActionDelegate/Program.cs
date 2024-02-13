namespace ActionDelegate
{
    public class Program
    {
        public static void SendNotification()
        {
            // Action delegate with one parameter
            Action<string> notify
                = (string message) => Console.WriteLine($"Received message: '{message}'");

            // Invoke the Action delegate
            notify("build project");
        }
    }
}