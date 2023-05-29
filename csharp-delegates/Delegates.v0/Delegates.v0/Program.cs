using Delegates.v0.Filters;
using Delegates.v0.Models;

Photo photo = new ("this is the path");

var bPhoto = Brightness.ApplyBrightness(photo);
var rPhoto = Resize.ResizePhoto(bPhoto);
rPhoto.Save("this is another path");