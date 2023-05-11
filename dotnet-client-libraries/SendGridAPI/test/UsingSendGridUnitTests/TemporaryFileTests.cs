// Copyright 2023 - Jeff Shergalis
// https://github.com/jshergal/stuce-dot-net-utilities
// 
// Licensed under the MIT License - http://www.opensource.org/licenses/mit-license.php
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE
// AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES
// OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT
// OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// 

using StuceSoftware.Utilities;

// File is originally part of the StuceSoftware.Utilities.Test project, but since there is no nuget package, just copying the code here
// so that we have tests around the TempFile class that is brought in from StuceSoftware.Utilities library
//namespace StuceSoftware.Utilities.Test; 

namespace UsingSendGridUnitTests;

public class TemporaryFileTests
{
    [Fact]
    public void GivenNewTemporaryFile_WhenConstructed_CreatesNewEmptyFile()
    {
        using var tempFile = new TemporaryFile();

        Assert.True(File.Exists(tempFile.FileName));
        Assert.Equal(0, new FileInfo(tempFile.FileName).Length);
    }

    [Fact]
    public void GivenNewTemporaryFile_WithSpecificExtension_CreatesTempFileWithExpectedExtension()
    {
        const string expectedExtension = ".ext";
        using var tempFile = new TemporaryFile(expectedExtension);

        Assert.Equal(expectedExtension, Path.GetExtension(tempFile.FileName));
    }

    [Fact]
    public void GivenTemporaryFile_WhenDisposed_DeletesFile()
    {
        var tempFile = new TemporaryFile();

        Assert.True(File.Exists(tempFile.FileName));

        tempFile.Dispose();
        Assert.False(File.Exists(tempFile.FileName));
    }

    [Fact]
    public void GivenNewTemporaryFile_WithSpecifiedNonExistingDirectory_CreatesDirectory()
    {
        var tempPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        Assert.False(Directory.Exists(tempPath));

        using (_ = new TemporaryFile(directory: tempPath))
        {
            Assert.True(Directory.Exists(tempPath));
        }

        Directory.Delete(tempPath, true);
    }

    [Fact]
    public async void GivenTemporaryFile_WhenAsyncDisposed_DeletesFile()
    {
        var fileName = await CreateTempFileAsynchronously().ConfigureAwait(false);
        Assert.False(File.Exists(fileName));
    }

    // Helper method to verify AsyncDispose is called correctly
    private static async Task<string> CreateTempFileAsynchronously()
    {
        await using var tempFile = new TemporaryFile();
        var buffer = new byte[128];
        Random.Shared.NextBytes(buffer);
        await File.WriteAllBytesAsync(tempFile.FileName, buffer).ConfigureAwait(false);

        Assert.True(File.Exists(tempFile.FileName));

        return tempFile.FileName;
    }
}