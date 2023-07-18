using System.Text;

namespace ITextBasics.ConsoleManager
{
    public class FakeConsole : IConsole
    {
        private StringBuilder _screenOutput;
        private List<ConsoleKeyInfo> _pressedKeys;
        private int _currentKeyIndex;

        public FakeConsole(StringBuilder screenOutput, List<ConsoleKeyInfo> pressedKeys)
        {
            _screenOutput = screenOutput;
            _pressedKeys = pressedKeys;
            _currentKeyIndex = 0;
        }

        public void Clear()
        {
            _screenOutput.Clear();
        }

        public void Write(string message)
        {
            _screenOutput.Append(message);
        }

        public void WriteLine(string message)
        {
            _screenOutput.AppendLine(message);
        }

        public ConsoleKeyInfo ReadKey()
        {
            if ((_pressedKeys is null) || (_pressedKeys.Count <= _currentKeyIndex))
                throw new InvalidOperationException("No keys pressed");

            return _pressedKeys[_currentKeyIndex++];
        }
    }
}
