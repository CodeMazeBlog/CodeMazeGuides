using PhotoFilters.Models;
using PhotoFilters.Delegates;
using PhotoFilters.Filters;
using PhotoFilters.v02.Filters;

namespace PhotoFilters.v02.NUnitTest
{
    public class PhotoFilterTests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void When_NoiseReduction_Then_OK()
        {
            bool success = false;
            try
            {
                Photo photo = new("path");

                FuncPhotoProcessor funcPhotoProcessor = new FuncPhotoProcessor();
                Func<Photo, Photo> funcProcessorHandler = NoiseReduction.SuppressBlackNoise;

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