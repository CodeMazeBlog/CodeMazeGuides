using System.Runtime.InteropServices;

namespace PathClassCsharpUnitTest
{
    public class PathClassTest
    {
        PathClass pathClass = new PathClass();

        [Test]
        public void WhenCallingDirectorySeparatorChar_ThenDirectorySeparatorCharIsReturned()
        {
            var directorySeparatorCharResult = pathClass.DirectorySeparatorChar();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(directorySeparatorCharResult, Is.EqualTo('/'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(directorySeparatorCharResult, Is.EqualTo('\\'));
            }
        }

        [Test]
        public void WhenCallingAltDirectorySeparatorChar_ThenAltDirectorySeparatorCharIsReturned()
        {
            var altDirectorySeparatorCharResult = pathClass.AltDirectorySeparatorChar();
            
            Assert.That(altDirectorySeparatorCharResult, Is.EqualTo('/'));
        }

        [Test]
        public void WhenCallingPathSeparator_ThenPathSeparatorCharIsReturned()
        {
            var pathSeparatorCharResult = pathClass.PathSeparator();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(pathSeparatorCharResult, Is.EqualTo(':'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(pathSeparatorCharResult, Is.EqualTo(';'));
            }
        }

        [Test]
        public void WhenCallingVolumeSeparatorChar_ThenVolumeSeparatorCharIsReturned()
        {
            var volumeSeparatorCharResult = pathClass.VolumeSeparatorChar();
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(volumeSeparatorCharResult, Is.EqualTo('/'));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(volumeSeparatorCharResult, Is.EqualTo(':'));
            }
        }

        [Test]
        public void WhenCallingGetInvalidPathChars_ThenInvalidPathCharsAreReturned()
        {
            var getInvalidPathCharsResult = pathClass.GetInvalidPathChars();

            int numberInvalidPathChars = 0;

            numberInvalidPathChars = getInvalidPathCharsResult.Length;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {                
                Assert.That(numberInvalidPathChars, Is.EqualTo(1));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {            
                Assert.That(numberInvalidPathChars, Is.EqualTo(33));                
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
            var firstResult = pathClass.EndsInDirectorySeparator(filepath);
            
            Assert.That(firstResult, Is.EqualTo(true));


            string filePathString = @"C:\MyDir\MySubDir\myfile.ext";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                filePathString = "/MyDir/MySubDir/myfile.ext";
            }            
            var secondResult = pathClass.EndsInDirectorySeparator(filePathString);
            
            Assert.That(secondResult, Is.EqualTo(false));
        }

        [Test]
        public void WhenCallingGetExtension_ThenFileExtensionIsReturned()
        {
            string pathFile = @"C:\mydir\myfile.com";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathFile = "/mydir/myfile.com";
            }            
            var getExtensionResult = pathClass.GetExtension(pathFile);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(getExtensionResult, Is.EqualTo(".com"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(getExtensionResult, Is.EqualTo(".com"));
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
            
            var changeExtensionResult = pathClass.ChangeExtension(pathFile, newExtension);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(changeExtensionResult, Is.EqualTo("/mydir/myfile.old"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(changeExtensionResult, Is.EqualTo("C:\\mydir\\myfile.old"));
            }
        }

        [Test]
        public void WhenCallingCombineTwoPaths_ThenCombinedPathStingIsReturned()
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
            
            var combinationResult = pathClass.Combine(path1, path2);            
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combinationResult, Is.EqualTo("/temp/subdir1"));
            }            
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combinationResult, Is.EqualTo("c:\\temp\\subdir1\\"));
            }
        }

        [Test]
        public void WhenCallingCombineThreePaths_ThenCombinedPathStingIsReturned()
        {
            string path1 = "c:\\temp";           
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path1 = "/temp";
            }

            string path2 = "subdir1\\";
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
            
            var combinationResult = pathClass.Combine(path1, path2, path3);
           
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combinationResult, Is.EqualTo("/temp/subdir1/subdir2/"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combinationResult, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\"));
            }
        }

        [Test]
        public void WhenCallingCombineFourPaths_ThenCombinedPathStingIsReturned()
        {
            string path1 = "c:\\temp";           
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                path1 = "/temp";
            }

            string path2 = "subdir1\\";
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
            
            var combinationResult = pathClass.Combine(path1, path2, path3, path4);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combinationResult, Is.EqualTo("/temp/subdir1/subdir2/file.txt"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combinationResult, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\file.txt"));
            }                        
        }

        [Test]
        public void WhenCallingCombinePathsArray_ThenCombinedPathStingIsReturned()
        {
            string[] paths = { @"d:\archives", "2001", "media", "image.txt" };
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                paths[0] = "/archives";
            }
            
            var combinationResult = pathClass.Combine(paths);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(combinationResult, Is.EqualTo("/archives/2001/media/image.txt"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(combinationResult, Is.EqualTo("d:\\archives\\2001\\media\\image.txt"));
            }
        }      

        [Test]
        public void WhenCallingGetDirectoryName_ThenDirectoryNameIsReturned()
        {
            string pathString = @"C:\MyDir\MySubDir\myfile.ext";
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathString = "/MyDir/MySubDir/myfile.ext";
            }
            
            var directoryName = pathClass.GetDirectoryName(pathString);
            
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

            var directory = pathClass.GetDirectoryName(fileName);
            
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
        public void WhenCallingGetFileName_ThenFileNameIsReturned()
        {
            ReadOnlySpan<char> filePath = "C:/Users/user1/file.exe".AsSpan();            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                filePath = "/Users/user1/file.exe".AsSpan();
            }            
            ReadOnlySpan<char> fileName = new Span<char>(new String(' ', 100).ToCharArray());
            
            fileName = pathClass.GetFileName(filePath);
            
            Assert.That(fileName.ToString(), Is.EqualTo("file.exe".AsSpan().ToString()));

            string filePathString = "C:/Users/user1/file.exe";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                filePathString = "/Users/user1/file.exe";
            }
            
            var fileNameString = pathClass.GetFileName(filePathString);
            
            Assert.That(fileNameString, Is.EqualTo("file.exe"));
        }

        [Test]
        public void WhenCallingTryJoin_ThenJoinedPathStringIsReturned()
        {
            Span<Char> firstDestination = new Span<Char>(new String(' ', 14).ToCharArray());            
            Span<Char> secondDestination = new Span<Char>(new String(' ', 34).ToCharArray());  
            
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
                firstDestination = new Span<Char>(new String(' ', 12).ToCharArray());
            }           
            
            int charsWritten = 0;
            
            pathClass.TryJoin(pathString1, pathString2, firstDestination, out charsWritten);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(firstDestination.ToString(), Is.EqualTo("/Users/user1".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(12));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(firstDestination.ToString(), Is.EqualTo("C:\\Users\\user1".AsSpan().ToString()));
                Assert.That(charsWritten, Is.EqualTo(14));
            }

            int chars = 0;
            Span<Char> destination = new Span<Char>(new String(' ', 33).ToCharArray());
            ReadOnlySpan<char> p1 = "C:/".AsSpan();               
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                p1 = "/";
                destination = new Span<Char>(new String(' ', 31).ToCharArray());
            }
            
            ReadOnlySpan<char> p2 = "Users/user1".AsSpan();
            
            ReadOnlySpan<char> p3 = "userName/file.text".AsSpan();
            
            

            pathClass.TryJoin(p1, p2, p3, destination, out chars);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(destination.ToString(), Is.EqualTo("/Users/user1/userName/file.text".AsSpan().ToString()));
                Assert.That(chars, Is.EqualTo(31));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(destination.ToString(), Is.EqualTo("C:/Users/user1\\userName/file.text".AsSpan().ToString()));
                Assert.That(chars, Is.EqualTo(33));
            }
        }

        [Test]
        public void WhenCallingGetFullPath_ThenFullPathStringIsReturned()
        {
            string basePath = "C:/Utilities/";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                basePath = "/Utilities";
            }            
            string relativePath = "data/output.xml";
            
            var pathStringResult = pathClass.GetFullPath(relativePath, basePath);
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Assert.That(pathStringResult, Is.EqualTo("/Utilities/data/output.xml"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Assert.That(pathStringResult, Is.EqualTo("C:\\Utilities\\data\\output.xml"));
            }           
        }

        [Test]
        public void WhenCallingGetPathRoot_ThenStringPathRootIsReturned()
        { 
            string fullPathString = @"C:\mydir\myfile.ext";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                fullPathString = "/mydir/myfile.ext";
            }
            
            var pathRoot = pathClass.GetPathRoot(fullPathString);
            
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
        public void WhenCallingJoin_ThenJoinedPathStingIsReturned()
        {
            string pathFirstComponent = "D:/";            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                //Linux StringPath
                pathFirstComponent = "/";
            }            
            string pathSecondComponent = "users/user1/documents";            
            string pathThirdComponent = "letters";
            
            var resultComponent = pathClass.Join(pathFirstComponent, pathSecondComponent, pathThirdComponent);
            
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
                pathArrayComponents[0] = "";
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