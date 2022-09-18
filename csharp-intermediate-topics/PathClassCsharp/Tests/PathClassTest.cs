using System.IO;
using System.Runtime.InteropServices;

namespace PathClassCsharpUnitTest
{
    public class PathClassTest
    {
        PathClass pathClass = new PathClass();

        [Test]
        public void WhenCallingDirectorySeparatorChar_ThenDirectorySeparatorCharIsRetrieved()
        {
            char DirectorySeparatorChar_Result = pathClass.DirectorySeparatorChar();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(DirectorySeparatorChar_Result, Is.EqualTo('/'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(DirectorySeparatorChar_Result, Is.EqualTo('\\'));
            }
        }

        [Test]
        public void WhenCallingAltDirectorySeparatorChar_ThenAltDirectorySeparatorCharIsRetrieved()
        {
            char AltDirectorySeparatorChar_Result = pathClass.AltDirectorySeparatorChar();
            Assert.That(AltDirectorySeparatorChar_Result, Is.EqualTo('/'));
        }

        [Test]
        public void WhenCallingPathSeparator_ThenPathSeparatorCharIsRetrieved()
        {
            char PathSeparatorChar_Result = pathClass.PathSeparator();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(PathSeparatorChar_Result, Is.EqualTo(':'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(PathSeparatorChar_Result, Is.EqualTo(';'));
            }
        }

        [Test]
        public void WhenCallingVolumeSeparatorChar_ThenVolumeSeparatorCharIsRetrieved()
        {
            char VolumeSeparatorChar_Result = pathClass.VolumeSeparatorChar();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(VolumeSeparatorChar_Result, Is.EqualTo('/'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(VolumeSeparatorChar_Result, Is.EqualTo(':'));
            }
        }

        [Test]
        public void WhenCallingGetInvalidPathChars_ThenInvalidPathCharsAreRetrieved()
        {
            char[] GetInvalidPathChars_Result = pathClass.GetInvalidPathChars();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {                
                Assert.That(GetInvalidPathChars_Result[0], Is.EqualTo('\u0000'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                char[] Result = { '|' };
                Assert.That(GetInvalidPathChars_Result[0], Is.EqualTo('|'));
                Assert.That(GetInvalidPathChars_Result[1], Is.EqualTo('\u0000'));
            }
        }

        [Test]
        public void WhenCallingChangeExtension_ThenFileExtensionIsChanged()
        {
            string pathFile = @"C:\mydir\myfile.com";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathFile = "/mydir/myfile.com";
            }
            string newExtension = ".old";
            string ChangeExtension_Result = pathClass.ChangeExtension(pathFile, newExtension);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(ChangeExtension_Result, Is.EqualTo("/mydir/myfile.old"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(ChangeExtension_Result, Is.EqualTo("C:\\mydir\\myfile.old"));
            }
        }

        [Test]
        public void WhenCallingCombineTwoPaths_ThenPathStingIsReturned()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path1 = "/temp";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path2 = "subdir1";
            }
            string combination_Result = pathClass.Combine(path1, path2);            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combination_Result, Is.EqualTo("/temp/subdir1"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\"));
            }
        }

        [Test]
        public void WhenCallingCombineThreePaths_ThenPathStingIsReturned()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path1 = "/temp";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path2 = "subdir1";
            }
            string path3 = "subdir2\\";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path3 = "subdir2/";
            }
            string combination_Result = pathClass.Combine(path1, path2, path3);
           
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combination_Result, Is.EqualTo("/temp/subdir1/subdir2/"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\"));
            }
        }

        [Test]
        public void WhenCallingCombineFourPaths_ThenPathStingIsReturned()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path1 = "/temp";
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path2 = "subdir1";
            }
            string path3 = "subdir2\\";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path3 = "subdir2/";
            }
            string path4 = "file.txt";
            string combination_Result = pathClass.Combine(path1, path2, path3, path4);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combination_Result, Is.EqualTo("/temp/subdir1/subdir2/file.txt"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\file.txt"));
            }                        
        }

        [Test]
        public void WhenCallingCombinePathsArray_ThenPathStingIsReturned()
        {
            string[] paths = { @"d:\archives", "2001", "media", "image.txt" };
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                paths[0] = "/archives";
            }
            string combination_Result = pathClass.Combine(paths);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combination_Result, Is.EqualTo("/archives/2001/media/image.txt"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combination_Result, Is.EqualTo("d:\\archives\\2001\\media\\image.txt"));
            }
        }

        [Test]
        public void WhenCallingEndsInDirectorySeparator_ThenBoolVariableIsReturned()
        {
            ReadOnlySpan<char> filepath = "C:/Users/user1/".AsSpan();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                filepath = "/Users/user1/".AsSpan();
            }
            bool first_result = pathClass.EndsInDirectorySeparator(filepath);
            Assert.That(first_result, Is.EqualTo(true));

            string filePathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                filePathString = "/MyDir/MySubDir/myfile.ext";
            }
            bool second_result = pathClass.EndsInDirectorySeparator(filePathString);
            Assert.That(second_result, Is.EqualTo(false));
        }

        [Test]
        public void WhenCallingGetDirectoryName_ThenDirectoryNameIsReturned()
        {
            string PathString = @"C:\MyDir\MySubDir\myfile.ext";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                PathString = "/MyDir/MySubDir/myfile.ext";
            }
            string directoryName = pathClass.GetDirectoryName(PathString);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(directoryName, Is.EqualTo("/MyDir/MySubDir"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(directoryName, Is.EqualTo("C:\\MyDir\\MySubDir"));
            }           

            string fileName = @"C:\mydir.old\myfile.ext";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                fileName = "/mydir.old/myfile.ext";
            }
            string directory = pathClass.GetDirectoryName(fileName);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(directory, Is.EqualTo("/mydir.old"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(directory, Is.EqualTo("C:\\mydir.old"));
            }           
        }

        [Test]
        public void WhenCallingGetFileName_ThenFileNameIsReturnes()
        {
            ReadOnlySpan<char> file_path = "C:/Users/user1/file.exe".AsSpan();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                file_path = "/Users/user1/file.exe".AsSpan();
            }
            ReadOnlySpan<char> file_name = new Span<char>(new String(' ', 100).ToCharArray());
            file_name = pathClass.GetFileName(file_path);
            Assert.That(file_name.ToString(), Is.EqualTo("file.exe".AsSpan().ToString()));

            string file_path_string = "C:/Users/user1/file.exe";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                file_path_string = "/Users/user1/file.exe";
            }
            string file_name_string = pathClass.GetFileName(file_path_string);
            Assert.That(file_name_string, Is.EqualTo("file.exe"));
        }

        [Test]
        public void WhenCallingTryJoin_ThenPathStringIsReturned()
        {
            ReadOnlySpan<char> pathString1 = "C:\\".AsSpan();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathString1 = "/";
            }
            ReadOnlySpan<char> pathString2 = "Users\\user1".AsSpan();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathString2 = "Users/user1";
            }
            Span<Char> first_destination = new Span<Char>(new String(' ', 14).ToCharArray());
            int charsWritten = 0;
            pathClass.TryJoin(pathString1, pathString2, first_destination, out charsWritten);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(first_destination.ToString(), Is.EqualTo("/Users/user1".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(12));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(first_destination.ToString(), Is.EqualTo("C:\\Users\\user1".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(14));
            }                      

            ReadOnlySpan<char> pathString3 = "user_name\\file.text".AsSpan();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathString3 = "user_name/file.text";
            }
            Span<Char> second_destination = new Span<Char>(new String(' ', 34).ToCharArray());
            pathClass.TryJoin(pathString1, pathString2, pathString3, second_destination, out charsWritten);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(second_destination.ToString(), Is.EqualTo("/Users/user1/user_name/file.text".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(32));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(second_destination.ToString(), Is.EqualTo("C:\\Users\\user1\\user_name\\file.text".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(34));
            }
        }

        [Test]
        public void WhenCallingGetFullPath_ThenPathStringIsReturned()
        {
            string basePath = "C:/Utilities/";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                basePath = "/Utilities";
            }
            string relativePath = "data/output.xml";
            string pathstringresult = pathClass.GetFullPath(relativePath, basePath);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(pathstringresult, Is.EqualTo("/Utilities/data/output.xml"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(pathstringresult, Is.EqualTo("C:\\Utilities\\data\\output.xml"));
            }           
        }

        [Test]
        public void GetPathRoot()
        {
            string full_path_string = @"C:\mydir\myfile.ext";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                full_path_string = "/mydir/myfile.ext";
            }
            string pathRoot = pathClass.GetPathRoot(full_path_string);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(pathRoot, Is.EqualTo("/"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(pathRoot, Is.EqualTo("C:\\"));
            }           
        }

        [Test]
        public void Join()
        {
            string pathFirstComponent = "D:/";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathFirstComponent = "/";
            }
            string pathSecondComponent = "users/user1/documents";
            string pathThirdComponent = "letters";
            string resultComponent = pathClass.Join(pathFirstComponent, pathSecondComponent, pathThirdComponent);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(resultComponent, Is.EqualTo("/users/user1/documents/letters"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(resultComponent, Is.EqualTo("D:/users/user1/documents\\letters"));
            }

            string[] pathArrayComponents = { "D:", "/users/user1/documents", "letters" };
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathArrayComponents[0] = "/";
            }
            resultComponent = pathClass.Join(pathArrayComponents);
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(resultComponent, Is.EqualTo("/users/user1/documents/letters"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(resultComponent, Is.EqualTo("D:/users/user1/documents\\letters"));
            }           
        }
    }
}