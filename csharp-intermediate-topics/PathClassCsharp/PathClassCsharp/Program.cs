namespace PathClassCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PathClass pathClass = new PathClass();

            var directorySeparatorCharResult = pathClass.DirectorySeparatorChar();

            var altDirectorySeparatorCharResult = pathClass.AltDirectorySeparatorChar();           
        
            var pathSeparatorResult = pathClass.PathSeparator();

            var volumeSeparatorCharResult = pathClass.VolumeSeparatorChar();

            var getInvalidPathCharsResult = pathClass.GetInvalidPathChars();

            ReadOnlySpan<char> filepath = "C:/Users/user1/".AsSpan();            
            if (!Path.IsPathFullyQualified(filepath))
            {
                //Linux StringPath
                filepath = "/Users/user1/".AsSpan();
            }

            var result = pathClass.EndsInDirectorySeparator(filepath);

            string filePathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (!Path.IsPathFullyQualified(filePathString))
            {
                //Linux StringPath
                filePathString = "/MyDir/MySubDir/myfile.ext";
            } 
            
            result = pathClass.EndsInDirectorySeparator(filePathString);

            string pathFile = @"C:\mydir\myfile.com";
            if (!Path.IsPathFullyQualified(pathFile))
            {
                //Linux StringPath
                pathFile = "/mydir/myfile.com";
            }
            
            var getExtensionResult = pathClass.GetExtension(pathFile);

            string newExtension = ".old";
            
            var changeExtensionResult = pathClass.ChangeExtension(pathFile, newExtension);

            string path1 = "c:\\temp";            
            string path2 = "subdir1\\";        
            if (!Path.IsPathFullyQualified(path1))
            {
                //Linux StringPath
                path1 = "/temp";
            }
            
            if (!Path.IsPathFullyQualified(path2))
            {
                //Linux StringPath
                path2 = "subdir1";
            }
            
            var combinationResult = pathClass.Combine(path1, path2);       

            string path3 = "subdir2\\";
            if (!Path.IsPathFullyQualified(path3))
            {
                //Linux StringPath
                path3 = "subdir2/";
            }
            
            combinationResult = pathClass.Combine(path1, path2, path3);

            string[] paths = { @"d:\archives", "2001", "media", "image.txt" };
            if (!Path.IsPathFullyQualified(paths[0]))
            {
                //Linux StringPath
                paths[0] = "/archives";
            }           
            
            combinationResult = pathClass.Combine(paths);                      
                        
            string pathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (!Path.IsPathFullyQualified(pathString))
            {
                //Linux StringPath
                pathString = "/MyDir/MySubDir/myfile.ext";
            }
            
            var directoryName = pathClass.GetDirectoryName(pathString);

            string fileName = @"C:\mydir.old\myfile.ext";            
            if (!Path.IsPathFullyQualified(fileName))
            {
                //Linux StringPath
                fileName = "/mydir.old/myfile.ext";
            }
            
            var directory = pathClass.GetDirectoryName(fileName);

            ReadOnlySpan<char> filePath = "C:/Users/user1/file.exe".AsSpan();            
            if (!Path.IsPathFullyQualified(filePath))
            {
                //Linux StringPath
                filePath = "/Users/user1/file.exe".AsSpan();
            }
            
            ReadOnlySpan<char> fileNameString = pathClass.GetFileName(filePath);

            string fileStringName = "C:/Users/user1/file.exe";            
            if (!Path.IsPathFullyQualified(fileStringName))
            {
                //Linux StringPath
                fileStringName = "/Users/user1/file.exe";
            }
            
            var file = pathClass.GetFileName(fileStringName);

            ReadOnlySpan<char> pathString1 = "C:/".AsSpan();            
            if (!Path.IsPathFullyQualified(pathString1))
            {
                //Linux StringPath
                pathString1 = "/";
            }            
            ReadOnlySpan<char> pathString2 = "Users/user1".AsSpan();            
            Span<Char> destination = new Span<Char>(new String(' ', 100).ToCharArray());            
            int charsWritten = 0;
            
            pathClass.TryJoin(pathString1, pathString2, destination, out charsWritten);

            ReadOnlySpan<char> pathString3 = "userName/file.text".AsSpan();
            
            pathClass.TryJoin(pathString1, pathString2, pathString3, destination, out charsWritten);

            string mydirPath = @"mydir";
            
            var pathResult = pathClass.GetFullPath(mydirPath);

            string basePath = "C:/Utilities/";            
            if (!Path.IsPathFullyQualified(basePath)) 
            {
                //Linux StringPath
                basePath = "/Utilities";
            }
            string relativePath = "data/output.xml";
            
            var pathStringResult = pathClass.GetFullPath(relativePath, basePath);

            string fullPathString = @"C:\mydir\myfile.ext";            
            if (!Path.IsPathFullyQualified(fullPathString))
            {
                //Linux StringPath
                fullPathString = "/mydir/myfile.ext";
            }

            var pathRoot = pathClass.GetPathRoot(fullPathString);

            string pathFirstComponent = "D:/";            
            if (!Path.IsPathFullyQualified(pathFirstComponent))
            {
                //Linux StringPath
                pathFirstComponent = "/";
            }            
            string pathSecondComponent = "users/user1/documents";            
            string pathThirdComponent = "letters";
            
            var resultComponent = pathClass.Join(pathFirstComponent, pathSecondComponent, pathThirdComponent);
            
            string[] pathArrayComponents = { "D:/", "users/user1/documents", "letters" };            
            if (!Path.IsPathFullyQualified(pathArrayComponents[0]))
            {
                //Linux StringPath
                pathArrayComponents[0] = "/";
            }
            
            resultComponent = pathClass.Join(pathArrayComponents);
        }
    }
}



