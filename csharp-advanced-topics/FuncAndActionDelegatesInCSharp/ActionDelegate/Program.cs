namespace ActionDelegate
{
    public class Program
    {
        public static void SendNotification()
        {
            Action<string> notify
                = (string message) => Console.WriteLine($"Received message: '{message}'");

            notify("build project");
        }
    }
}