using PhotoFilters.Models;

namespace PhotoFilters.v02.Filters
{
    public class NoiseReduction
    {
        public static Photo SuppressWhiteNoise(Photo photo)
        {
            Console.WriteLine("Aplying NR White to photo...");
            Console.WriteLine("Done!");

            return photo;
        }
        public static Photo SuppressBlackNoise(Photo photo)
        {
            Console.WriteLine("Aplying NR Black to photo...");
            Console.WriteLine("Done!");

            return photo;
        }
    }
}
