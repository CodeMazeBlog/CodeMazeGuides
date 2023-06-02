using Delegates.v0.Models;

namespace Delegates.v0.Filters
{
    internal class Brightness
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
