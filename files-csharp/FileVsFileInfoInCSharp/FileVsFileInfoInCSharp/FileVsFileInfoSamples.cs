using System.Text;

namespace FileVsFileInfoInCSharp
{
    public static class FileVsFileInfoSamples
    {
        public static (FileStream, FileStream) CreateFile()
        {
            //Create file Using the File class
            using FileStream fileCreatedUsingFileClass = File.Create("myFileOne.txt");

            //Create a file using the FileInfo class 
            FileInfo fileInfo = new("myFileTwo.txt");
            using FileStream fileCreatedUsingFileInfoClass = fileInfo.Create();

            return (fileCreatedUsingFileClass, fileCreatedUsingFileInfoClass);
        }

        public static (FileStream, FileStream) OpenFile()
        {
            //Open a file using File classs
            using FileStream fileOne = File.Open("myFileThree.txt", FileMode.Create);
            fileOne.Dispose();
            File.Delete("myFileThree.txt");

            //Open a file in Create mode with FileInfo
            FileInfo fileInfo = new("myFileTwelve.txt");
            using FileStream result = fileInfo.Open(FileMode.Create);
            result.Dispose();
            fileInfo.Delete();

            //Open a file with FileMode.Create, FileAccess.Write using File 
            using FileStream fileAccess = File.Open("myFileThree.txt", FileMode.Create, FileAccess.Write);
            fileAccess.Close();
            File.Delete("myFileThree.txt");

            //Open a file with FileMode.Create, FileAccess.Write using FileInfo 
            using FileStream fileInfoAccess = fileInfo.Open(FileMode.Create, FileAccess.Write);
            fileInfoAccess.Close();
            fileInfoAccess.Dispose();
            fileInfo.Delete();

            //Open a file with FileMode.Create, FileAccess.Write, FileShare.ReadWrite using File 
            using FileStream share = File.Open("myFileZ.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            share.Close();
            share.Dispose();

            //Open a file with FileMode.Create, FileAccess.Write using File 
            using FileStream infoShare = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            infoShare.Close();
            infoShare.Dispose();

            //Open a file with FileStreamOptions
            var fileStreamOptions = new FileStreamOptions()
            {
                Access = FileAccess.Read,
                Share = FileShare.ReadWrite,
                Mode = FileMode.OpenOrCreate
            };

            using FileStream fileStream = File.Open("myFileTwentyTwo.txt", fileStreamOptions);
            fileStream.Dispose();
            File.Delete("myFileTwentyTwo.txt");

            //Open a file with FileStreamOptions using FileInfo
            using FileStream fileInfoFileStream = fileInfo.Open(fileStreamOptions);
            fileInfoFileStream.Close();
            fileInfoFileStream.Dispose();

            return (fileOne, result);
        }

        public static (FileStream, FileStream) OpenReadFile()
        {
            //Open a read-only file stream with static File.OpenRead()            
            if (!File.Exists("sampleReadOnlyFileTwo.txt"))
            {
                var fs = File.Create("sampleReadOnlyFileTwo.txt");
                fs.Close();
            }
            using FileStream openReadFileResult = File.OpenRead("sampleReadOnlyFileTwo.txt");

            openReadFileResult.Close();
            openReadFileResult.Dispose();
            File.Delete("sampleReadOnlyFileTwo.txt");

            //Open a read-only file stream with instance FileInfo.OpenRead()
            FileInfo fileInfo = new("myFileTwo.txt");
            if (!fileInfo.Exists) fileInfo.Create();

            using FileStream openReadFileInfoResult = fileInfo.OpenRead();

            openReadFileInfoResult.Dispose();
            fileInfo.Delete();

            return (openReadFileInfoResult, openReadFileResult);
        }

        public static (FileStream, FileStream) OpenWriteFile()
        {
            //Open or Create a write-only file stream with static File.OpenWrite()
            using FileStream openWriteFileResult = File.OpenWrite("myFileFive.txt");
            openWriteFileResult.Dispose();
            File.Delete("myFileFive.txt");

            //Open or Create a write-only file stream with instance FileInfo.OpenWrite()
            FileInfo fileInfo = new("myFileFourteen.txt");
            using FileStream openWriteFileInfoResult = fileInfo.OpenWrite();

            openWriteFileInfoResult.Dispose();
            fileInfo.Delete();

            return (openWriteFileInfoResult, openWriteFileResult);
        }

        public static string CreateReadAndWriteViaFile()
        {
            if (!File.Exists("sampleDocument.txt"))
            {
                //To create a file
                using StreamWriter streamWriter = File.CreateText("sampleDocument.txt");
                //To write to the file
                streamWriter.WriteLine("My Todo");
                Console.WriteLine();
                streamWriter.WriteLine("Drink Water");
                streamWriter.WriteLine("Be Awesome");
            }
            //To open and read from the created .txt file
            using StreamReader streamReader = File.OpenText("sampleDocument.txt");
            string result;

            StringBuilder sr = new();
            while ((result = streamReader.ReadLine()) != null)
            {
                sr.Append(result);
            }

            return sr.ToString();
        }

        public static string CreateReadAndWriteViaFileInfo()
        {
            FileInfo fileInfo = new("SampleDocument.txt");

            if (!fileInfo.Exists)
            {
                //To create a file
                using StreamWriter streamWriter = fileInfo.CreateText();
                //To write to the file
                streamWriter.WriteLine("My Todo");
                streamWriter.WriteLine("Drink Water");
                streamWriter.WriteLine("Be Awesome");
            }
            //To open and read from the created .txt file
            using StreamReader streamReader = fileInfo.OpenText();
            string result;

            StringBuilder sr = new();
            while ((result = streamReader.ReadLine()) != null)
            {
                sr.Append(result);
            }

            return sr.ToString();
        }

        public static void RefreshMethodOfFileInfo()
        {
            FileInfo fileInfo = new("myFileFifteen.txt");

            fileInfo.Attributes = FileAttributes.Hidden;
            fileInfo.Refresh();
            Console.WriteLine(fileInfo.Attributes.ToString());
            fileInfo.Delete();
        }

        public static void UsingFileOnMultipleFiles()
        {
            File.Copy("myFileSix.txt", "myFileSeven.txt");
            File.Encrypt("myFileSix.txt");
            File.Decrypt("myFileSix.txt");
            File.Move("myFileSeven.txt", "myFileSix.txt");
            File.Delete("myFileSix.txt");
            File.Delete("myFileSeven.txt");
        }

        public static void UsingFileInfoOnOneFile()
        {
            FileInfo fileInfo = new("myFileSixteen.txt");
            fileInfo.OpenText();
            fileInfo.Encrypt();
            fileInfo.Decrypt();
            fileInfo.Delete();
        }
    }
}
