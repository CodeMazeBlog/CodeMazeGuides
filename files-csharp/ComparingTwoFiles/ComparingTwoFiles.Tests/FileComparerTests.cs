namespace ComparingTwoFiles.Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("batch1/hello-world.txt", "batch2/hello-world.txt")]
    public void GivenDifferentFiles_WhenCompareByBytes_ThenReturnsFalse(string file1, string file2)
    {
        var result = FileComparer.CompareByBytes(FullPath(file1), FullPath(file2));
        Assert.False(result);
    }

    [Theory]
    [InlineData("batch1/hello-world.txt", "batch2/hello-world.txt")]
    public void GivenDifferentFiles_WhenCompareByChecksum_ThenReturnsFalse(string file1, string file2)
    {
        var result = FileComparer.CompareByChecksum(FullPath(file1), FullPath(file2));
        Assert.False(result);
    }

    [Theory]
    [InlineData("batch2/hello-world.txt", "batch2/unchanged-hello-world.txt")]
    public void GivenSimilarFiles_WhenCompareByBytes_ThenReturnsTrue(string file1, string file2)
    {
        var result = FileComparer.CompareByBytes(FullPath(file1), FullPath(file2));
        Assert.True(result);
    }

    [Theory]
    [InlineData("batch2/hello-world.txt", "batch2/unchanged-hello-world.txt")]
    public void GivenSimilarFiles_WhenCompareByChecksum_ThenReturnsTrue(string file1, string file2)
    {
        var result = FileComparer.CompareByChecksum(FullPath(file1), FullPath(file2));
        Assert.True(result);
    }

    [Theory]
    [InlineData("batch2/hello-world.txt", "batch2/unchanged-hello-world.txt")]
    public void GivenDifferentNameFiles_WhenCompareByNameAndSize_ThenReturnsFalse(string file1, string file2)
    {
        var result = FileComparer.CompareByNameAndSize(FullPath(file1), FullPath(file2), StringComparison.OrdinalIgnoreCase);
        Assert.False(result);
    }

    [Theory]
    [InlineData("batch1/hello-world.txt", "batch2/hello-world.txt")]
    public void GivenSameNameAndSizeFiles_WhenCompareByNameAndSize_ThenReturnsTrue(string file1, string file2)
    {
        var result = FileComparer.CompareByNameAndSize(FullPath(file1), FullPath(file2), StringComparison.OrdinalIgnoreCase);
        Assert.True(result);
    }

    private static string FullPath(string name)
    {
        var filesDir = Path.Combine(Directory.GetCurrentDirectory(), "files");
        return Path.Combine(filesDir, name);
    }
}