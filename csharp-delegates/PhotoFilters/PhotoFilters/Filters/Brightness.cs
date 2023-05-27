using PhotoFilters.Models;

namespace PhotoFilters.Filters
{
    public static class Brightness
    {
        public static Photo ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Aplying brightness to photo...");
            Console.WriteLine("Done!");
            return photo;
        }
        public static void ApplyBrightnessAndSave(Photo photo)
        {
            Console.WriteLine("Aplying brightness to photo...");
            Console.WriteLine("Saving photo...");
            Console.WriteLine("Done!");
        }
    }
}
