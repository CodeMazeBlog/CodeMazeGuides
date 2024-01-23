using GenerateRandomBooleans.RandomGenerators;

namespace GenerateRandomBooleans.BooleanGenerators
{
    public class GetItemsWithBufferGenerator(IRandomGenerator randomGenerator, int bufferLength) : IBooleanGenerator
    {
        private readonly IRandomGenerator _randomGenerator = randomGenerator;
        private readonly int _bufferLength = bufferLength;

        private readonly int _maxBufferIndex = bufferLength;
        private readonly bool[] _allPossibilities = [false, true];

        private int _currentBufferIndex = bufferLength;
        private bool[] _buffer = [];

        public bool NextBool()
        {
            if (_currentBufferIndex >= _maxBufferIndex)
            {
                _buffer = _randomGenerator.GetItems<bool>(_allPossibilities, _bufferLength);
                _currentBufferIndex = 0;
            }

            return _buffer[_currentBufferIndex++];
        }
    }
}
