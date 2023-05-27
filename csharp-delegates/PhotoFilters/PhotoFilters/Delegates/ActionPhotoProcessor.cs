using PhotoFilters.Models;

namespace PhotoFilters.Delegates
{
    public class ActionPhotoProcessor
    {
        public void Process(Photo photo, Action<Photo> handler)
        {
            handler(photo);
        }
    }
}
