namespace ActionFuncDelegatesInCsharp
{
    public static class Helper
    {
        /// <summary>
        /// Helper method to log messages
        /// For demo purposed we are logging to console
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Log(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}
