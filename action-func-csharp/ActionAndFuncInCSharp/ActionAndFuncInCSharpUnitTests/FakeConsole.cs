using ActionAndFuncInCSharp;

namespace ActionAndFuncInCSharpUnitTests
{
    internal class FakeConsole : IConsole
    {
        private List<string> _messages = new List<string>();

        public string[] Messages => _messages.ToArray();


        public void WriteLine(string message)
        {
            _messages.Add(message);
        }

        public void WriteLine(int message)
        {
            _messages.Add(message.ToString());
        }

        public void WriteLine(bool message)
        {
            _messages.Add(message.ToString());
        }
    }
}
