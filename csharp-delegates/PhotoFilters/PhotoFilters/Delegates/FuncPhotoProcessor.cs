using PhotoFilters.Models;

namespace PhotoFilters.Delegates
{
    public class FuncPhotoProcessor
    {
        public Photo Process(Photo photo, Func<Photo, Photo> handler)
        {
            handler(photo);

            return photo;
        }
    }
}
