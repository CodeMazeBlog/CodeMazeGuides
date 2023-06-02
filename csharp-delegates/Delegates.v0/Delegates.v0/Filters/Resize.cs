using Delegates.v0.Models;

namespace Delegates.v0.Filters
{
    internal class Resize
    {
        public static Photo ResizePhoto(Photo photo)
        {
            Console.WriteLine("Resizing photo...");
            Console.WriteLine("Done!");

            return photo;
        }
    }
}
