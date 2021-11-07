namespace AsyncFuncInCSharp
{
    public static class ActionDelegate
    {
        public static void NotifyMeByAction(string message, DateTime notificationTime)
        {
            Console.WriteLine($"Process {message} at: {notificationTime}.");
        }
    }
}
