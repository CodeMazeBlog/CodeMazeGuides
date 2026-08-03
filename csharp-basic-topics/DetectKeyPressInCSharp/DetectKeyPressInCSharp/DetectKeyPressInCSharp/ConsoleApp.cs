namespace DetectKeyPressInCSharp
{
    public class ConsoleApp
    {
        private readonly IConsoleService _consoleService;

        public ConsoleApp(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        public void ReadKeyUse()
        {
            for (int i = 0; i < 2; i++)
            {
                _consoleService.WriteLine("Press any key to continue...");
                var keyInfo = _consoleService.ReadKey();
                _consoleService.WriteLine("\nYou pressed: " + keyInfo.Key);
            }
            _consoleService.WriteLine("Process stopped");
            _consoleService.ReadKey();
        }

        public void KeyAvailableUse()
        {
            do
            {   
                _consoleService.WriteLine("Press 'x' to stop!");
                Thread.Sleep(10);
                _consoleService.Clear();
            } while (!(_consoleService.KeyAvailable && _consoleService.ReadKey(true).Key == ConsoleKey.X));
            _consoleService.WriteLine("Process stopped");
        }
    }
}
