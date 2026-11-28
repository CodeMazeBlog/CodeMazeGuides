using DirectoryAndDirectoryInfo;

namespace Tests
{
    public class SafePathsTests
    {
        private readonly string _root = Path.Combine(Path.GetTempPath(), "CM-Demos", "SubFolder");

        [Theory]
        [InlineData("report.txt")]
        [InlineData("reports/2026/report.txt")]
        [InlineData("reports/../report.txt")]
        public void GivenPathInsideRoot_WhenResolveInsideIsCalled_ThenFullPathIsReturned(string userInput)
        {
            var resolved = SafePaths.ResolveInside(_root, userInput);

            Assert.NotNull(resolved);
            Assert.StartsWith(_root + Path.DirectorySeparatorChar, resolved);
        }

        [Theory]
        [InlineData("../notes.txt")]
        [InlineData("../../secret.txt")]
        [InlineData("../SubFolder2/report.txt")]
        public void GivenPathOutsideRoot_WhenResolveInsideIsCalled_ThenNullIsReturned(string userInput)
        {
            Assert.Null(SafePaths.ResolveInside(_root, userInput));
        }
    }
}
