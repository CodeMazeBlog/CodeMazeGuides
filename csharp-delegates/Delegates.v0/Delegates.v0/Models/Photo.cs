namespace Delegates.v0.Models
{
    internal class Photo
    {
        public Photo(string path)
        {
            Load(path);
        }

        public void Load(string path)
        {
            Console.WriteLine("Loading photo...");
        }

        public void Save(string path)
        {
            Console.WriteLine("Saving photo...");
        }
    }
}
