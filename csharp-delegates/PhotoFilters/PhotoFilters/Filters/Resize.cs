using PhotoFilters.Models;

namespace PhotoFilters.Filters
{
    public class Resize
    {
        public static Photo ResizePhoto(Photo photo)
        {
            Console.WriteLine("Resizing photo...");
            Console.WriteLine("Done!");

            return photo;
        }
    }
}
