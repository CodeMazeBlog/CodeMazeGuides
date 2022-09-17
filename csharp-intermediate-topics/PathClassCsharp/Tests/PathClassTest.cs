using System.IO;


namespace PathClassCsharpUnitTest
{
    public class PathClassTest
    {
        PathClass pathClass = new PathClass();

        [Test]
        public void DirectorySeparatorChar()
        {
            char DirectorySeparatorChar_Result = pathClass.DirectorySeparatorChar();
            Assert.That(DirectorySeparatorChar_Result, Is.EqualTo('\\'));
        }

        [Test]
        public void AltDirectorySeparatorChar()
        {
            char AltDirectorySeparatorChar_Result = pathClass.AltDirectorySeparatorChar();
            Assert.That(AltDirectorySeparatorChar_Result, Is.EqualTo('/'));
        }


        [Test]
        public void PathSeparator()
        {
            char PathSeparatorChar_Result = pathClass.PathSeparator();
            Assert.That(PathSeparatorChar_Result, Is.EqualTo(';'));
        }

        [Test]
        public void VolumeSeparatorChar()
        {
            char VolumeSeparatorChar_Result = pathClass.VolumeSeparatorChar();
            Assert.That(VolumeSeparatorChar_Result, Is.EqualTo(':'));
        }

        [Test]
        public void GetInvalidPathChars()
        {
            char[] GetInvalidPathChars_Result = pathClass.GetInvalidPathChars();
            char[] Result = { '|' };
            Assert.That(GetInvalidPathChars_Result[0], Is.EqualTo('|'));
            Assert.That(GetInvalidPathChars_Result[1], Is.EqualTo('\u0000'));
        }

        [Test]
        public void ChangeExtension()
        {
            string pathFile = @"C:\mydir\myfile.com";
            string newExtension = ".old";
            string ChangeExtension_Result = pathClass.ChangeExtension(pathFile, newExtension);
            Assert.That(ChangeExtension_Result, Is.EqualTo("C:\\mydir\\myfile.old"));
        }

        [Test]
        public void CombineTwoPaths()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            string combination_Result = pathClass.Combine(path1, path2);
            Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\"));
        }

        [Test]
        public void CombineThreePaths()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            string path3 = "subdir2\\";
            string combination_Result = pathClass.Combine(path1, path2, path3);
            Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\"));
        }

        [Test]
        public void CombineFourPaths()
        {
            string path1 = "c:\\temp";
            string path2 = "subdir1\\";
            string path3 = "subdir2\\";
            string path4 = "file.txt";
            string combination_Result = pathClass.Combine(path1, path2, path3, path4);
            Assert.That(combination_Result, Is.EqualTo("c:\\temp\\subdir1\\subdir2\\file.txt"));
        }


        [Test]
        public void CombinePathsArray()
        {
            string[] paths = { @"d:\archives", "2001", "media", "image.txt" };
            string combination_Result = pathClass.Combine(paths);
            Assert.That(combination_Result, Is.EqualTo("d:\\archives\\2001\\media\\image.txt"));
        }

        [Test]
        public void EndsInDirectorySeparator()
        {
            ReadOnlySpan<char> filepath = "C:/Users/user1/".AsSpan();
            bool first_result = pathClass.EndsInDirectorySeparator(filepath);
            Assert.That(first_result, Is.EqualTo(true));

            string filePathString = @"C:\MyDir\MySubDir\myfile.ext";
            bool second_result = pathClass.EndsInDirectorySeparator(filePathString);
            Assert.That(second_result, Is.EqualTo(false));
        }

        [Test]
        public void GetDirectoryName()
        {
            string PathString = @"C:\MyDir\MySubDir\myfile.ext";
            string directoryName = pathClass.GetDirectoryName(PathString);
            Assert.That(directoryName, Is.EqualTo("C:\\MyDir\\MySubDir"));

            string fileName = @"C:\mydir.old\myfile.ext";
            string directory = pathClass.GetDirectoryName(fileName);
            Assert.That(directory, Is.EqualTo("C:\\mydir.old"));
        }


        [Test]
        public void GetFileName()
        {
            ReadOnlySpan<char> file_path = "C:/Users/user1/file.exe".AsSpan();
            ReadOnlySpan<char> file_name = new Span<char>(new String(' ', 100).ToCharArray());
            file_name = pathClass.GetFileName(file_path);
            Assert.That(file_name.ToString(), Is.EqualTo("file.exe".AsSpan().ToString()));

            string file_path_string = "C:/Users/user1/file.exe";
            string file_name_string = pathClass.GetFileName(file_path_string);
            Assert.That(file_name_string, Is.EqualTo("file.exe"));
        }

        [Test]
        public void TryJoin()
        {
            ReadOnlySpan<char> pathString1 = "C:\\".AsSpan();
            ReadOnlySpan<char> pathString2 = "Users\\user1".AsSpan();
            Span<Char> first_destination = new Span<Char>(new String(' ', 14).ToCharArray());
            int charsWritten = 0;
            pathClass.TryJoin(pathString1, pathString2, first_destination, out charsWritten);
            Assert.That(first_destination.ToString(), Is.EqualTo("C:\\Users\\user1".AsSpan().ToString()));
            Assert.That(charsWritten, Is.EqualTo(14));

            ReadOnlySpan<char> pathString3 = "user_name\\file.text".AsSpan();
            Span<Char> second_destination = new Span<Char>(new String(' ', 34).ToCharArray());
            pathClass.TryJoin(pathString1, pathString2, pathString3, second_destination, out charsWritten);
            Assert.That(second_destination.ToString(), Is.EqualTo("C:\\Users\\user1\\user_name\\file.text".AsSpan().ToString()));
            Assert.That(charsWritten, Is.EqualTo(34));
        }

        [Test]
        public void GetFullPath()
        {
            string mydir_path = @"mydir";
            string PathResult = pathClass.GetFullPath(mydir_path);
            Assert.That(PathResult, Is.EqualTo("C:\\Projects\\CodeMazeGuides\\csharp-intermediate-topics\\PathClassCsharp\\Tests\\bin\\Debug\\net6.0\\mydir"));

            string basePath = "C:/Utilities/";
            string relativePath = "./data/output.xml";
            string pathstringresult = pathClass.GetFullPath(relativePath, basePath);
            Assert.That(pathstringresult, Is.EqualTo("C:\\Utilities\\data\\output.xml"));
        }

        [Test]
        public void GetPathRoot()
        {
            string full_path_string = @"C:\mydir\myfile.ext";
            string pathRoot = pathClass.GetPathRoot(full_path_string);
            Assert.That(pathRoot, Is.EqualTo("C:\\"));
        }

        [Test]
        public void Join()
        {
            string pathFirstComponent = "D:/";
            string pathSecondComponent = "users/user1/documents";
            string pathThirdComponent = "letters";
            string resultComponent = pathClass.Join(pathFirstComponent, pathSecondComponent, pathThirdComponent);
            Assert.That(resultComponent, Is.EqualTo("D:/users/user1/documents\\letters"));

            string[] pathArrayComponents = { "D:", "/users/user1/documents", "letters" };
            resultComponent = pathClass.Join(pathArrayComponents);
            Assert.That(resultComponent, Is.EqualTo("D:/users/user1/documents\\letters"));
        }
    }
}