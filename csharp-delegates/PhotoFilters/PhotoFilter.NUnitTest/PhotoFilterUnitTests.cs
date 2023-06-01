using PhotoFilters.Delegates;
using PhotoFilters.Filters;
using PhotoFilters.Models;

namespace PhotoFilter.NUnitTest
{
    public class PhotoFilterUnitTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void ActionPhotoProcessor_When_ApplyBrightnessAndSave_Then_Photo()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                ActionPhotoProcessor actionPhotoProcessor = new();
                Action<Photo> actionProcessorHandler = Brightness.ApplyBrightnessAndSave;

                Console.WriteLine("Action Delegate");
                actionPhotoProcessor.Process(photo, actionProcessorHandler);

                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }

            Assert.That(success, Is.True);
        }

        [Test]
        public void FuncPhotoProcessor_When_ApplyBrightness_Then_Photo()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                FuncPhotoProcessor funcPhotoProcessor = new();
                Func<Photo, Photo> funcProcessorHandler = Brightness.ApplyBrightness;

                Console.WriteLine("Func Delegate");
                funcPhotoProcessor.Process(photo, funcProcessorHandler);

                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }

            Assert.That(success, Is.True);
        }

        [Test]
        public void FuncPhotoProcessor_When_Resize_Then_Photo()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                FuncPhotoProcessor funcPhotoProcessor = new();
                Func<Photo, Photo> funcProcessorHandler = Resize.ResizePhoto;

                Console.WriteLine("Func Delegate");
                funcPhotoProcessor.Process(photo, funcProcessorHandler);

                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }

            Assert.That(success, Is.True);
        }

        [Test]
        public void FuncPhotoProcessor_When_Contrast_Then_Photo()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                FuncPhotoProcessor funcPhotoProcessor = new();
                Func<Photo, Photo> funcProcessorHandler = Contrast.ContrastPhoto;

                Console.WriteLine("Func Delegate");
                funcPhotoProcessor.Process(photo, funcProcessorHandler);

                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }

            Assert.That(success, Is.True);
        }
    }
}