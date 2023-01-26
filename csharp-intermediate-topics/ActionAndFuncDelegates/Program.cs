namespace ActionAndFuncDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<LogLevel, string> LogMessage = WriteLog;
            LogMessage(LogLevel.Warning, "Something is missing");
            LogMessage(LogLevel.Error, "Something is wrong");

            Func<string, string, string> GetFullName = Concat;
            var fullName = GetFullName("Code", "maze");
            Console.WriteLine(fullName);
        }

        public enum LogLevel
        {
            Warning,
            Error
        }

        public static void WriteLog(LogLevel logLevel, string message)
        {
            switch (logLevel)
            {
                case LogLevel.Warning:
                    Console.WriteLine($"{LogLevel.Warning} - {message}");
                    break;
                case LogLevel.Error:
                    Console.WriteLine($"{LogLevel.Error} - {message}");
                    break;
                default:
                    break;
            }
        }

        public static string Concat(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }
    }
}