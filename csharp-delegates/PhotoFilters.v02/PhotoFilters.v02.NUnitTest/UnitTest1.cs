using PhotoFilters.Models;
using PhotoFilters.Delegates;
using PhotoFilters.Filters;
using PhotoFilters.v02.Filters;

namespace PhotoFilters.v02.NUnitTest
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

        [Test]
        public void FuncPhotoProcessor_NoiseReduction()
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