using System;
using System.IO;

namespace PathClassCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AltDirectorySeparatorChar: provides a platform-specific alternate character used to separate directory levels in a path string that reflects a hierarchical file system organization
            Console.WriteLine($"Path.AltDirectorySeparatorChar: '{Path.AltDirectorySeparatorChar}'");
            #endregion

            #region DirectorySeparatorChar: provides a platform-specific character used to separate directory levels in a path string that reflects a hierarchical file system organization
            Console.WriteLine($"Path.DirectorySeparatorChar: '{Path.DirectorySeparatorChar}'");
            #endregion

            #region PathSeparator: a platform-specific separator character used to separate path strings in environment variables
            Console.WriteLine($"Path.PathSeparator: '{Path.PathSeparator}'");
            #endregion

            #region VolumeSeparatorChar: provides a platform-specific volume separator character
            Console.WriteLine($"Path.VolumeSeparatorChar: '{Path.VolumeSeparatorChar}'");
            #endregion

            #region GetInvalidPathChars(): we get an array containing the characters that are not allowed in path names
            var invalidChars = Path.GetInvalidPathChars();
            Console.WriteLine($"Path.GetInvalidPathChars:");
            for (int ctr = 0; ctr < invalidChars.Length; ctr++)
            {
                Console.Write($"  U+{Convert.ToUInt16(invalidChars[ctr]):X4} ");
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region ChangeExtension(String, String): we change the extension of a path string
            PathSamples.result = Path.ChangeExtension(PathSamples.path, ".old");
            Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", PathSamples.path, PathSamples.result);
            #endregion

            #region Combine(String, String): we combine two strings into a path
            PathSamples.combination = Path.Combine(PathSamples.path1, PathSamples.path2);
            Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}'{3}'",
                               PathSamples.path1, PathSamples.path2, Environment.NewLine, PathSamples.combination);
            #endregion

            #region Combine(String, String, String): we combine three strings into a path
            PathSamples.combined = Path.Combine(PathSamples.p1, PathSamples.p2, PathSamples.p3);
            Console.WriteLine(PathSamples.combined);
            #endregion

            #region Combine(String, String, String, String): we combine four strings into a path
            PathSamples.combined = Path.Combine(PathSamples.p1, PathSamples.p4, PathSamples.p2, PathSamples.p3);
            Console.WriteLine(PathSamples.combined);
            #endregion

            #region Combine(String[]): we combines an array of strings into a path
            PathSamples.combined = Path.Combine(PathSamples.paths);
            Console.WriteLine(PathSamples.combined);
            #endregion

            #region EndsInDirectorySeparator(ReadOnlySpan<Char>): returns a value that indicates whether the path ends in a directory separator
            PathSamples.boolResult = Path.EndsInDirectorySeparator(PathSamples.filepath);
            Console.WriteLine("EndsInDirectorySeparator('{0}') returns '{1}'", PathSamples.filepath.ToString(), PathSamples.boolResult.ToString());

            PathSamples.boolResult = Path.EndsInDirectorySeparator(PathSamples.filepath);
            Console.WriteLine("EndsInDirectorySeparator('{0}') returns '{1}'", PathSamples.filepath.ToString(), PathSamples.boolResult.ToString());
            #endregion

            #region GetDirectoryName(String): returns the directory information for the specified path
            int i = 0;

            while (PathSamples.filePath != null)
            {
                PathSamples.directoryName = Path.GetDirectoryName(PathSamples.filePath);
                Console.WriteLine("GetDirectoryName('{0}') returns '{1}'", PathSamples.filePath, PathSamples.directoryName);
                PathSamples.filePath = PathSamples.directoryName;
                if (i == 1)
                {
                    PathSamples.filePath = PathSamples.directoryName + @"\";  // this will preserve the previous path
                }
                i++;
            }
            #endregion

            #region GetExtension(String): returns the extension(including the period ".") of the specified path string
            PathSamples.fileName = @"C:\mydir.old\myfile.ext";
            PathSamples.extensionString = Path.GetExtension(PathSamples.fileName);
            Console.WriteLine("GetExtension('{0}') returns '{1}'", PathSamples.fileName, PathSamples.extensionString);
            #endregion

            #region GetFileName(ReadOnlySpan<Char>): returns the file name and extension of a file path that is represented by a read-only character span
            ReadOnlySpan<char> Result = new Span<char>(new String(' ', 100).ToCharArray());
            Result = Path.GetFileName(PathSamples.filename);
            Console.WriteLine("GetFileName('{0}') returns '{1}'", PathSamples.filename.ToString(), Result.ToString());
            #endregion

            #region GetFileName(String): returns the file name and extension of the specified path string.
            PathSamples.result = Path.GetFileName(PathSamples.file_name);
            Console.WriteLine("GetFileName('{0}') returns '{1}'",
                PathSamples.file_name, PathSamples.result);

            PathSamples.result = Path.GetFileName(PathSamples.dir_path);
            Console.WriteLine("GetFileName('{0}') returns '{1}'",
                PathSamples.dir_path, PathSamples.result);
            #endregion

            #region TryJoin(ReadOnlySpan<Char>, ReadOnlySpan<Char>, Span<Char>, Int32): attempts to concatenate two path components to a single preallocated character span, and returns a value that indicates whether the operation succeeded.
            if (Path.TryJoin("C:/".AsSpan(), "Users/user1".AsSpan(), PathSamples.buffer, out PathSamples.nChars))
                Console.WriteLine($"Wrote {PathSamples.nChars} characters: '{PathSamples.buffer.Slice(0, PathSamples.nChars).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
            #endregion

            #region TryJoin(ReadOnlySpan<Char>, ReadOnlySpan<Char>, ReadOnlySpan<Char>, Span<Char>, Int32): attempts to concatenate three path components to a single preallocated character span, and returns a value that indicates whether the operation succeeded.
            if (Path.TryJoin("C:/".AsSpan(), "Users/user1".AsSpan(), "/docs".AsSpan(), PathSamples.buffer, out PathSamples.nChars))
                Console.WriteLine($"Wrote {PathSamples.nChars} characters: '{PathSamples.buffer.Slice(0, PathSamples.nChars).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
            #endregion

            #region GetFullPath(String): returns the absolute path for the specified path string.     
            PathSamples.PathResult = Path.GetFullPath(PathSamples.mydir_path);
            Console.WriteLine("GetFullPath('{0}') returns '{1}'", PathSamples.mydir_path, PathSamples.PathResult);
            #endregion

            #region GetFullPath(String, String): returns an absolute path from a relative path and a fully qualified base path.
            PathSamples.pathString = Path.GetFullPath(PathSamples.relativePath, PathSamples.basePath);
            Console.WriteLine($"Fully qualified path:\n {PathSamples.pathString}");
            #endregion

            #region GetPathRoot: gets the root directory information from the path contained in the specified string.
            PathSamples.pathRoot= Path.GetPathRoot(PathSamples.fullPathString); 
            Console.WriteLine("GetPathRoot('{0}') returns '{1}'", PathSamples.fullPathString, PathSamples.pathRoot);
            #endregion

            #region Join(String, String, String): 
            Console.WriteLine($"Path.Join: '{Path.Join(PathSamples.pathFirstComponent, PathSamples.pathSecondComponent, PathSamples.pathThirdComponent)}'");
            #endregion

            #region Join(String[]) concatenates an array of paths into a single path.
            Console.WriteLine($"Path.Join: '{Path.Join(PathSamples.pathArrayComponent)}'");
            #endregion
        }
    }
}



