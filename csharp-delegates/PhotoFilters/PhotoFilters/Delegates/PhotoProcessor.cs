using PhotoFilters.Models;

namespace PhotoFilters.Delegates
{
    public class PhotoProcessor
    {
        public delegate Photo PhotoProcessorHandler(Photo photo);

        public Photo Process(Photo photo, PhotoProcessorHandler handler)
        {
            handler(photo);
            return photo;
        }
    }
}
