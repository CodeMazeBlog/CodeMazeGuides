using static FileVsFileInfoInCSharp.FileVsFileInfoSamples;

namespace Test
{
    public class FileVsFileInfoTest
    {
        [Fact]
        public void GivenCreateFile_WhenExecuted_ReturnsATuple()
        {
            (FileStream, FileStream) result = CreateFile();

            Assert.IsType<(FileStream, FileStream)>(result);
        }

        [Fact]
        public void GivenOpenFile_WhenExecuted_ReturnsATuple()
        {
            (FileStream, FileStream) result = OpenFile();

            Assert.IsType<(FileStream, FileStream)>(result);
        }

        [Fact]
        public void GivenOpenReadFile_WhenExecuted_ReturnsATuple()
        {
            (FileStream, FileStream) result = OpenReadFile();

            Assert.IsType<(FileStream, FileStream)>(result);
        }

        [Fact]
        public void GivenOpenWriteFile_WhenExecuted_ReturnsATuple()
        {
            (FileStream, FileStream) result = OpenWriteFile();

            Assert.IsType<(FileStream, FileStream)>(result);
        }

        [Fact]
        public void GivenCreateReadAndWriteViaFileInfo_WhenExecuted_ReturnsAString()
        {
            string result = CreateReadAndWriteViaFileInfo();

            Assert.IsType<string>(result);

            Assert.Equal("My TodoDrink WaterBe Awesome", result);
        }

        [Fact]
        public void GivenCreateReadAndWriteViaFile_WhenExecuted_ReturnsAString()
        {
            string result = CreateReadAndWriteViaFile();

            Assert.IsType<string>(result);

            Assert.Equal("My TodoDrink WaterBe Awesome", result);
        }       
    }
}
