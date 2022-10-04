namespace PathClassCSharp
{
    public class PathClass
    {
        public char DirectorySeparatorChar()
        {
            var result = Path.DirectorySeparatorChar;
            Console.WriteLine($"Path.DirectorySeparatorChar: '{result}'");
            
            return result;
        }

        public char AltDirectorySeparatorChar()
        {
            var result = Path.AltDirectorySeparatorChar;            
            Console.WriteLine($"Path.AltDirectorySeparatorChar: '{result}'");
            
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
            var result = Path.VolumeSeparatorChar;            
            Console.WriteLine($"Path.VolumeSeparatorChar: '{result}'");
            
            return result;
        }

        public char[] GetInvalidPathChars()
        {
            var result = $"Path.GetInvalidPathChars:";
            var invalidChars = Path.GetInvalidPathChars();        
            Console.WriteLine(result);
            
            foreach (var item in invalidChars)
            {
                Console.Write($"{item} ");
            }            
            Console.WriteLine();
            
            return (invalidChars);
        }

        public bool EndsInDirectorySeparator(ReadOnlySpan<Char> filePath)
        {
            var result = Path.EndsInDirectorySeparator(filePath);            
            Console.WriteLine($"EndsInDirectorySeparator('{filePath.ToString()}') returns '{result.ToString()}'");
            
            return result;
        }

        public bool EndsInDirectorySeparator(string filePath)
        {
            var result = Path.EndsInDirectorySeparator(filePath);            
            Console.WriteLine($"EndsInDirectorySeparator('{filePath}') returns '{result.ToString()}'");
            
            return result;
        }

        public string GetExtension(string fileName)
        {
            var extensionString = Path.GetExtension(fileName);            
            Console.WriteLine($"GetExtension('{fileName}') returns '{extensionString}'");
            
            return extensionString;
        }

        public string ChangeExtension(string path, string newExtension)
        {            
            var result= Path.ChangeExtension(path, newExtension);            
            Console.WriteLine($"ChangeExtension({path}, '.old') returns '{result}'");
            
            return (result);
        }

        public string Combine(string path1, string path2)
        {
            var combination = Path.Combine(path1, path2);            
            Console.WriteLine($"When you combine '{path1}' and '{path2}', the result is: {Environment.NewLine}'{combination}'");

            return combination;
        }

        public string Combine(string path1, string path2, string path3)
        {
            var combination = Path.Combine(path1, path2, path3);            
            Console.WriteLine($"When you combine '{path1}' and '{path2}' and '{path3}', the result is: {Environment.NewLine}'{combination}'");
            
            return combination;
        }

        public string Combine(string path1, string path2, string path3, string path4)
        {
            var combination = Path.Combine(path1, path2, path3, path4);            
            Console.WriteLine($"When you combine '{path1}' and '{path2}' and '{path3}' and '{path4}', the result is: {Environment.NewLine}'{combination}'");
            
            return combination;
        }

        public string Combine(String[] paths)
        {
            var combination = Path.Combine(paths);            
            Console.WriteLine($"When you combine '{paths[0]}' and '{paths[1]}' and '{paths[2]}' and '{paths[3]}', the result is: {Environment.NewLine}'{combination}'");
            
            return combination;
        }

        public string GetDirectoryName(string filePath)
        {
            var directoryName = Path.GetDirectoryName(filePath);            
            Console.WriteLine($"GetDirectoryName('{filePath}') returns '{directoryName}'");
            
            return directoryName;
        }

        public ReadOnlySpan<char> GetFileName(ReadOnlySpan<Char> filePath)
        {
            ReadOnlySpan<char> fileName = Path.GetFileName(filePath);            
            Console.WriteLine($"GetFileName('{filePath.ToString()}') returns '{fileName.ToString()}'");
            
            return fileName;
        }

        public string GetFileName(string fileName)
        {
            var result = Path.GetFileName(fileName);            
            Console.WriteLine($"GetFileName('{fileName}') returns '{result}'");
            
            return result;
        }

        public string GetFullPath(string mydirPath)
        {
            var pathResult = Path.GetFullPath(mydirPath);            
            Console.WriteLine($"GetFullPath('{mydirPath}') returns '{pathResult}'");
            
            return pathResult;
        }

        public string GetFullPath(string path, string basePath)
        {
            var pathResult = Path.GetFullPath(path, basePath);            
            Console.WriteLine($"Fully qualified path:\n {pathResult}");
            
            return pathResult;
        }

        public string GetPathRoot(string fullPathString)
        {
            var pathRoot = Path.GetPathRoot(fullPathString);            
            Console.WriteLine($"GetPathRoot('{fullPathString}') returns '{pathRoot}'");
            
            return pathRoot;
        }

        public void TryJoin(ReadOnlySpan<Char> path1, ReadOnlySpan<Char> path2, Span<Char> destination, out Int32 charsWritten)
        {
            if (Path.TryJoin(path1, path2, destination, out charsWritten))
                Console.WriteLine($"Wrote {charsWritten} characters: '{destination.Slice(0, charsWritten).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
        }

        public void TryJoin(ReadOnlySpan<Char> path1, ReadOnlySpan<Char> path2, ReadOnlySpan<Char> path3, Span<Char> destination, out Int32 charsWritten)
        {
            if (Path.TryJoin(path1, path2, path3, destination, out charsWritten))
                Console.WriteLine($"Wrote {charsWritten} characters: '{destination.Slice(0, charsWritten).ToString()}'");
            else
                Console.WriteLine("Concatenation operation failed.");
        }

        public string Join(string path1, string path2, string path3)
        {
            var result = Path.Join(path1, path2, path3);            
            Console.WriteLine($"Path.Join: '{result}'");
            
            return result;
        }

        public string Join(string[] pathArrayComponents)
        {
            var result = Path.Join(pathArrayComponents);            
            Console.WriteLine($"Path.Join: '{result}'");
            
            return result;
        }      
    }
}
