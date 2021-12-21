using System;
using System.IO;

namespace Polymorphism
{
    public enum LogLevels
    {
        Info = 1,
        Warning = 2,
        Error = 3
    }

    public class Logger
    {
        private StreamWriter LogFile;
        public Logger(StreamWriter logFile)
        {
            LogFile = logFile;
        }

        public void Log(string message, LogLevels level)
        {
            LogFile.Write(level + " ---");
            LogFile.Write(DateTime.Now.ToString() + " ---");
            LogFile.WriteLine(message);
            LogFile.Flush();
        }

        public void Log(string message)
        {
            Log(message, LogLevels.Info);
        }

        public void Log(string message, int level)
        {
            if (Enum.IsDefined(typeof(LogLevels), level))
            {
                Log(message, (LogLevels)Enum.Parse(typeof(LogLevels), level.ToString()));
            }
            else
            {
                throw new Exception("Log level value does not exist");
            }
        }
    }
}
