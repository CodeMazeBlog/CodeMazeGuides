namespace IndexersInCSharp
{
    public class Sentence
    {
        private string[] _words;
        public int Length => _words.Length;

        public Sentence(string sentence)
        {
            if (sentence == null)
                throw new ArgumentNullException(nameof(sentence));

            _words = sentence.Split(' ');
        }

        public string this[int wordNumber]
        {
            get
            {
                if (wordNumber < 0 || wordNumber > _words.Length - 1)
                    throw new ArgumentOutOfRangeException(nameof(wordNumber));

                return _words[wordNumber];
            }
            set
            {
                if (wordNumber < 0 || wordNumber > _words.Length - 1)
                    throw new ArgumentOutOfRangeException(nameof(wordNumber));

                if (value == null || value.Trim().Length == 0 || value.Split(' ').Length > 1)
                    return;

                _words[wordNumber] = value;
            }
        }
    }
}
