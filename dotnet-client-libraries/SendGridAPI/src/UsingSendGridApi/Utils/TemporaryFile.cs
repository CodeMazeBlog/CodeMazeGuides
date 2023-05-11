// Copyright 2009 - 2023 - Jeff Shergalis
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

namespace StuceSoftware.Utilities;

/// <summary>
///     Class for generating and temporary files.  The file will be created in the
///     constructor and then cleaned up when the class is disposed.
/// </summary>
public sealed class TemporaryFile : IDisposable, IAsyncDisposable
{
    #region Constructors

    /// <summary>
    ///     Intitializes a new instance of the <see cref="TemporaryFile" /> class.
    /// </summary>
    /// <param name="extension">The extension to append to the temporary file.</param>
    /// <param name="directory">The directory to create the temporary file in.</param>
    public TemporaryFile(string? extension = null, string? directory = null) =>
        FileName = CreateTemporaryFile(extension, directory);

    #endregion

    #region Fields

    /// <summary>
    ///     Gets the name of the temporary file.
    /// </summary>
    public string FileName { get; }

    #endregion

    #region Methods

    /// <summary>
    ///     Generates a unique temporary file with the specified extension in the specified
    ///     directory.
    /// </summary>
    /// <param name="extension">The extension for the generated file.</param>
    /// <param name="directory">The directory to generate the file in.</param>
    private static string CreateTemporaryFile(string? extension, string? directory)
    {
        // If no path is specified use system temp path
        if (string.IsNullOrEmpty(directory))
            directory = Path.GetTempPath();
        // Ensure the directory exists
        else if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

        // If no extension specified use .tmp
        if (string.IsNullOrEmpty(extension)) extension = ".tmp";

        while (true)
        {
            var fileName = Path.Combine(directory, Path.ChangeExtension(Path.GetRandomFileName(), extension));
            if (File.Exists(fileName)) continue;
            try
            {
                // try to create the file
                new FileStream(fileName, FileMode.CreateNew).Dispose();
                return fileName;
            }
            catch (IOException)
            {
                // Just eat IO exceptions since they are caused by the file existing
            }
        }
    }

    #endregion

    #region IDisposable

    /// <summary>
    ///     Tries to ensure that the temporary file is deleted
    /// </summary>
    public void Dispose()
    {
        DisposeInternal();
        GC.SuppressFinalize(this);
    }

    private void DisposeInternal()
    {
        try
        {
            // Ensure there is a file name and the file still exists
            if (!string.IsNullOrWhiteSpace(FileName) && File.Exists(FileName))
                File.Delete(FileName); // Try to delete the file
        }
        catch
        {
            // Just eat exceptions in the dispose method
        }
    }

    /// <summary>
    ///     Finalizer, last chance to clean up the temporary file if dispose was not called
    /// </summary>
    ~TemporaryFile()
    {
        DisposeInternal();
    }

    public ValueTask DisposeAsync()
    {
        DisposeInternal();
        GC.SuppressFinalize(this);

        return ValueTask.CompletedTask;
    }

    #endregion
}