using PhotoFilters.Delegates;
using PhotoFilters.Filters;
using PhotoFilters.Models;
using PhotoFilters.v02.Filters;

namespace PhotoFiltering.NUnitTest
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void ActionPhotoProcessor_FuncDelegate_Brightness()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                FuncPhotoProcessor funcPhotoProcessor = new FuncPhotoProcessor();
                Func<Photo, Photo> funcProcessorHandler = Brightness.ApplyBrightness;

                //Console.WriteLine("Function Delegate");
                var fPhoto = funcPhotoProcessor.Process(photo, funcProcessorHandler);

                success = true;
            }
            catch (Exception e)
            {
                success = false;
            }
            Assert.That(success, Is.True);
        }

        [Test]
        public void ActionPhotoProcessor_ActionDelegate_Brightness()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                ActionPhotoProcessor actionPhotoProcessor = new ActionPhotoProcessor();
                Action<Photo> actionProcessorHandler = Brightness.ApplyBrightnessAndSave;

                //Console.WriteLine("Action Delegate");
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
        public void ActionPhotoProcessor_CustomDelegate_Brightness_Contrast_Noise()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");
                PhotoProcessor processor = new PhotoProcessor();

                PhotoProcessor.PhotoProcessorHandler processorHandler = Brightness.ApplyBrightness;
                processorHandler += Contrast.ContrastPhoto;
                processorHandler += NoiseReduction.SuppressWhiteNoise;

                //Console.WriteLine("Custom Delegate");
                var newPhoto = processor.Process(photo, processorHandler);

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