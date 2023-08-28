namespace ActionFuncInCSharp
{
    public static class NotifierAction
    {
        public static void SendNotification(string message, Action<string> notificationMethod)
        {
            Console.WriteLine("Preparing to send notification: " + message);
            notificationMethod(message);
        }
    }
}
