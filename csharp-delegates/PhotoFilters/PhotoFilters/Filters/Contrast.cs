using PhotoFilters.Models;

namespace PhotoFilters.Filters
{
    public class Contrast
    {
        public static Photo ContrastPhoto(Photo photo)
        {
            Console.WriteLine("Contrasting photo...");
            Console.WriteLine("Done!");

            return photo;
        }
    }
}
