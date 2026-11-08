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

        [Fact]
        public void GivenRefreshMethodOfFileInfo_WhenFileIsCreatedElsewhere_ThenExistsIsStaleUntilRefresh()
        {
            var (beforeRefresh, afterRefresh) = RefreshMethodOfFileInfo();

            Assert.False(beforeRefresh);
            Assert.True(afterRefresh);
        }

        [Fact]
        public void GivenOpenWriteKeepsTheTail_WhenShorterTextIsWritten_ThenOldTailRemains()
        {
            string result = OpenWriteKeepsTheTail();

            Assert.Equal("Shortis a long line", result);
        }

        [Fact]
        public void GivenUsingFileOnMultipleFiles_WhenExecuted_ThenNoFileIsLeftBehind()
        {
            UsingFileOnMultipleFiles();

            Assert.False(File.Exists("myFileSix.txt"));
            Assert.False(File.Exists("myFileEight.txt"));
        }

        [Fact]
        public void GivenUsingFileInfoOnOneFile_WhenMoved_ThenInstanceFollowsTheFile()
        {
            string name = UsingFileInfoOnOneFile();

            Assert.Equal("myFileSixteenMoved.txt", name);
        }
    }
}
