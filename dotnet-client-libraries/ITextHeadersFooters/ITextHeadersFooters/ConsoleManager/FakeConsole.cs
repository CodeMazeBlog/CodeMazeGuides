namespace ITextHeadersFooters.ConsoleManager
{
    public class FakeConsole : IConsole, IConsoleLineCounter
    {
        private readonly List<ConsoleKeyInfo> _pressedKeys;
        private int _currentKeyIndex;
        private int _numberOfLines;

        public int NumberOfLines => _numberOfLines;

        public FakeConsole(List<ConsoleKeyInfo> pressedKeys)
        {
            _pressedKeys = pressedKeys;
            _currentKeyIndex = 0;
            _numberOfLines = 0;
        }

        public void Clear()
        {
            _numberOfLines = 0;
        }

        public void Write(string message)
        {
            if (_numberOfLines == 0)
                _numberOfLines++;
        }

        public void WriteLine(string message)
        {
            _numberOfLines++;
        }

        public ConsoleKeyInfo ReadKey()
        {
            if ((_pressedKeys is null) || (_pressedKeys.Count <= _currentKeyIndex))
                throw new InvalidOperationException("No keys pressed");

            return _pressedKeys[_currentKeyIndex++];
        }
    }
}
