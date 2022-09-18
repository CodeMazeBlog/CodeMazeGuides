using System.IO;
using System.Xml.XPath;

namespace PathClassCSharp
{
    public class PathClass
    {
        public char AltDirectorySeparatorChar()
        {
            char result = Path.AltDirectorySeparatorChar;
            Console.WriteLine($"Path.AltDirectorySeparatorChar: '{result}'");
            return result;
        }

        public char DirectorySeparatorChar()
        {
            char result = Path.DirectorySeparatorChar;
            Console.WriteLine($"Path.DirectorySeparatorChar: ' {result}'");
            return result;
        }

        public char PathSeparator()
        {
            var result =Path.PathSeparator;
            Console.WriteLine($"Path.PathSeparator: '{result}'");
            return result;
        }

        public char VolumeSeparatorChar()
        {
            char result = Path.VolumeSeparatorChar;
            Console.WriteLine($"Path.VolumeSeparatorChar: '{result}'");
            return result;
        }

        public char[] GetInvalidPathChars()
        {
            var result = $"Path.GetInvalidPathChars:";
            char[] invalidChars = Path.GetInvalidPathChars();          
            Console.WriteLine(result);
            for (int ctr = 0; ctr < invalidChars.Length; ctr++)
            {
                Console.Write($"  U+{Convert.ToUInt16(invalidChars[ctr]):X4} ");
                if ((ctr + 1) % 10 == 0) Console.WriteLine();
            }
            Console.WriteLine();
            return (invalidChars);
        }

        public string ChangeExtension(string path, string newExtension)
        {            
            string result= Path.ChangeExtension(path, newExtension);
            Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", path, result);
            return (result);
        }

        public string Combine(string path1, string path2)
        {
            string combination = Path.Combine(path1, path2);
            Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}'{3}'",
                               path1, path2, Environment.NewLine, combination);
            return combination;
        }

        public string Combine(string path1, string path2, string path3)
        {
            string combination = Path.Combine(path1, path2, path3);
            Console.WriteLine("When you combine '{0}' and '{1}' and '{2}', the result is: {3}'{4}'",
                               path1, path2, path3, Environment.NewLine, combination);
            return combination;
        }

        public string Combine(string path1, string path2, string path3, string path4)
        {
            string combination = Path.Combine(path1, path2, path3, path4);
            Console.WriteLine("When you combine '{0}' and '{1}' and '{2}' and '{3}', the result is: {4}'{5}'",
                               path1, path2, path3, path4, Environment.NewLine, combination);
            return combination;
        }

        public string Combine(String[] paths)
        {
            string combination = Path.Combine(paths);
            Console.WriteLine("When you combine '{0}' and '{1}' and '{2}' and '{3}', the result is: {4}'{5}'",
                               paths[0], paths[1], paths[2], paths[3], Environment.NewLine, combination);
            return combination;
        }
       
        public bool EndsInDirectorySeparator(ReadOnlySpan<Char> filePath)
        {
            bool result = Path.EndsInDirectorySeparator(filePath);
            Console.WriteLine("EndsInDirectorySeparator('{0}') returns '{1}'", filePath.ToString(), result.ToString());
            return result;
        }

        public bool EndsInDirectorySeparator(string filePath)
        {
            bool result = Path.EndsInDirectorySeparator(filePath);
            Console.WriteLine("EndsInDirectorySeparator('{0}') returns '{1}'", filePath, result.ToString());
            return result;
        }

        public string GetDirectoryName(string filepath)
        {
            string directoryName = Path.GetDirectoryName(filepath);
            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'", filepath, directoryName);
            return directoryName;
        }

        public string GetExtension(string fileName)
        {
            string extensionString = Path.GetDirectoryName(fileName);
            Console.WriteLine("GetExtension('{0}') returns '{1}'", fileName, extensionString);
            return extensionString;
        }

        public ReadOnlySpan<char> GetFileName(ReadOnlySpan<Char> filename)
        {
            ReadOnlySpan<char> Result = new Span<char>(new String(' ', 100).ToCharArray());
            Result = Path.GetFileName(filename);
            Console.WriteLine("GetFileName('{0}') returns '{1}'", filename.ToString(), Result.ToString());
            return Result;
        }

        public string GetFileName(string filename)
        {
            string Result = Path.GetFileName(filename);
            Console.WriteLine("GetFileName('{0}') returns '{1}'", filename, Result);
            return Result;
        }

        public bool TryJoin(ReadOnlySpan<Char> path1, ReadOnlySpan<Char> path2, Span<Char> destination, out Int32 charsWritten)
        {
            if (Path.TryJoin(path1, path2, destination, out charsWritten))
                Console.WriteLine($"Wrote {charsWritten} characters: '{destination.Slice(0, charsWritten).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
            return true;
        }

        public bool TryJoin(ReadOnlySpan<Char> path1, ReadOnlySpan<Char> path2, ReadOnlySpan<Char> path3, Span<Char> destination, out Int32 charsWritten)
        {
            if (Path.TryJoin(path1, path2, path3, destination, out charsWritten))
                Console.WriteLine($"Wrote {charsWritten} characters: '{destination.Slice(0, charsWritten).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
            return true;
        }

        public string GetFullPath(string mydir_path)
        {
            string PathResult = Path.GetFullPath(mydir_path);
            Console.WriteLine("GetFullPath('{0}') returns '{1}'", mydir_path, PathResult);
            return PathResult;
        }

        public string GetFullPath(string path, string basePath)
        {
            string PathResult = Path.GetFullPath(path, basePath);
            Console.WriteLine($"Fully qualified path:\n {PathResult}");
            return PathResult;
        }

        public string GetPathRoot(string fullPathString)
        {
            string pathRoot = Path.GetPathRoot(fullPathString);
            Console.WriteLine("GetPathRoot('{0}') returns '{1}'", fullPathString, pathRoot);
            return pathRoot;
        }

        public string Join(String path1, String path2, String path3)
        {
            string result = Path.Join(path1, path2, path3);
            Console.WriteLine($"Path.Join: '{Path.Join(path1, path2, path3)}'");
            return result;
        }

        public string Join(String[] pathArrayComponents)
        {
            string result = Path.Join(pathArrayComponents);
            Console.WriteLine($"Path.Join: '{Path.Join(pathArrayComponents)}'");
            return result;
        }
    }
}
