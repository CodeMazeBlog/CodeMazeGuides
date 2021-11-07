namespace ActionFuncInCSharp
{
    public static class FuncDelegate
    {
        public static string NotifyMeByFunc(string message, DateTime notificationTime)
        {
            return $"Process {message} at: {notificationTime}.";
        }
    }
}
