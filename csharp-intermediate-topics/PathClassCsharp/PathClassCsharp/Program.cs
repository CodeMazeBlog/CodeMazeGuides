using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PathClassCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PathClass pathClass = new PathClass();

            char DirectorySeparatorChar_Result = pathClass.DirectorySeparatorChar();

            char AltDirectorySeparatorChar_Result = pathClass.AltDirectorySeparatorChar();           
            
            char PathSeparator_Result = pathClass.PathSeparator();

            char VolumeSeparatorChar_Result = pathClass.VolumeSeparatorChar();

            char[] GetInvalidPathChars_Result = pathClass.GetInvalidPathChars();

            string pathFile = @"C:\mydir\myfile.com";           
            if (!Path.IsPathFullyQualified(pathFile))
            {
                //Linux StringPath
                pathFile = "/mydir/myfile.com";
            }
            string newExtension = ".old";
            string ChangeExtension_Result = pathClass.ChangeExtension(pathFile, newExtension);

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
                path2 = "another/path";
            }
            string combination_Result = pathClass.Combine(path1, path2);
           
            string path3 = "subdir2\\";
            if (!Path.IsPathFullyQualified(path3))
            {
                //Linux StringPath
                path3 = "additionaPath/";
            }
            combination_Result = pathClass.Combine(path1, path2, path3);

            string path4 = "file.txt";
            combination_Result = pathClass.Combine(path1, path2, path3, path4);

            string[] paths = { @"d:\archives", "2001", "media", "image.txt" };
            if (!Path.IsPathFullyQualified(paths[0]))
            {
                //Linux StringPath
                paths[0] = "/archives";
            }           
            combination_Result = pathClass.Combine(paths);

            ReadOnlySpan<char> filepath = "C:/Users/user1/".AsSpan();
            if (!Path.IsPathFullyQualified(filepath))
            {
                //Linux StringPath
                filepath = "/Users/user1/".AsSpan();
            }
            bool result = pathClass.EndsInDirectorySeparator(filepath);

            string filePathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (!Path.IsPathFullyQualified(filePathString))
            {
                //Linux StringPath
                filePathString = "/MyDir/MySubDir/myfile.ext";
            }
            result = pathClass.EndsInDirectorySeparator(filePathString);

            string PathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (!Path.IsPathFullyQualified(PathString))
            {
                //Linux StringPath
                PathString = "/MyDir/MySubDir/myfile.ext";
            }
            string directoryName = pathClass.GetDirectoryName(PathString);

            string fileName = @"C:\mydir.old\myfile.ext";
            if (!Path.IsPathFullyQualified(fileName))
            {
                //Linux StringPath
                fileName = "/mydir.old/myfile.ext";
            }
            string directory = pathClass.GetDirectoryName(fileName);

            ReadOnlySpan<char> file_path = "C:/Users/user1/file.exe".AsSpan();
            if (!Path.IsPathFullyQualified(file_path))
            {
                //Linux StringPath
                file_path = "/Users/user1/file.exe".AsSpan();
            }
            ReadOnlySpan<char> file_name = new Span<char>(new String(' ', 100).ToCharArray());
            file_name = pathClass.GetFileName(file_path);

            string file_path_string = "C:/Users/user1/file.exe";
            if (!Path.IsPathFullyQualified(file_path_string))
            {
                //Linux StringPath
                file_path_string = "/Users/user1/file.exe";
            }
            string file_name_string = pathClass.GetFileName(file_path_string);

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

            ReadOnlySpan<char> pathString3 = "user_name/file.text".AsSpan();
            pathClass.TryJoin(pathString1, pathString2, pathString3, destination, out charsWritten);

            string mydir_path = @"mydir";
            string PathResult = pathClass.GetFullPath(mydir_path);

            string basePath = "C:/Utilities/";
            if (!Path.IsPathFullyQualified(basePath)) 
            {
                //Linux StringPath
                basePath = "/Utilities/";
            }
            string relativePath = "./data/output.xml";
            string pathstringresult = pathClass.GetFullPath(relativePath, basePath);

            string full_path_string = @"C:\mydir\myfile.ext";
            if (!Path.IsPathFullyQualified(full_path_string))
            {
                //Linux StringPath
                full_path_string = "/mydir/myfile.ext";
            }
            string pathRoot = pathClass.GetPathRoot(full_path_string);

            string pathFirstComponent = "D:/";
            if (!Path.IsPathFullyQualified(pathFirstComponent))
            {
                //Linux StringPath
                pathFirstComponent = "/";
            }
            string pathSecondComponent = "users/user1/documents";
            string pathThirdComponent = "letters";
            string resultComponent = pathClass.Join(pathFirstComponent, pathSecondComponent, pathThirdComponent);

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



