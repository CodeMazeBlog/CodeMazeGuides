using System;

namespace ActionAndFuncDelegates.IO
{
    public class AppConsole : IAppConsole
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}