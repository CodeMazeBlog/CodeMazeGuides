namespace DetectKeyPressInCSharp
{
    public interface IConsoleService
    {
        void WriteLine(string message);
        ConsoleKeyInfo ReadKey(bool intercept = false);
        bool KeyAvailable { get; }
        void Clear();
    }

}
