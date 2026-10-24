namespace ReadOnlyModifierInCSharp
{
    public class Playlist
    {
        private readonly List<string> _songs = new();

        public int Count => _songs.Count;

        public void Add(string song)
        {
            _songs.Add(song);
        }

        public void Reset()
        {
            //_songs = new List<string>(); //Throws Compiler Error
        }
    }
}
