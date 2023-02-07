using System.Text;

namespace FileVsFileInfoInCSharp
{
    public static class Samples
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
            FileInfo fileInfo = new("myFileTwelve.txt");

            //Open a file using File classs
            using FileStream openFileWithFileClass = File.Open("myFileThree.txt", FileMode.Create);
            openFileWithFileClass.Dispose();
            File.Delete("myFileThree.txt");

            //Open a file in Create mode with FileInfo            
            using FileStream result = fileInfo.Open(FileMode.Create);
            result.Dispose();
            fileInfo.Delete();

            //Open a file with FileMode.Create, FileAccess.Write using File 
            using FileStream openFileWithFileClassWithFileAccess = File.Open("myFileThree.txt", FileMode.Create, FileAccess.Write);
            openFileWithFileClassWithFileAccess.Close();
            File.Delete("myFileThree.txt");

            //Open a file with FileMode.Create FileAccess.Write using File 
            using FileStream openFileInfoWithFileClassWithFileAccess = fileInfo.Open(FileMode.Create, FileAccess.Write);
            openFileInfoWithFileClassWithFileAccess.Close();
            openFileInfoWithFileClassWithFileAccess.Dispose();
            fileInfo.Delete();

            //Open a file with FileMode.Create, FileAccess.Write using File 
            using FileStream openFileWithFileClassWithFileShare = File.Open("myFileTwentyOne.txt", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            openFileWithFileClassWithFileAccess.Close();
            openFileWithFileClassWithFileAccess.Dispose();            

            //Open a file with FileMode.Create FileAccess.Write using File 
            using FileStream openFileInfoWithFileClassWithFileShare = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            openFileInfoWithFileClassWithFileAccess.Close();
            openFileInfoWithFileClassWithFileAccess.Dispose();            

            //Open a file with FileStreamOptions using File
            var fileStreamOptions = new FileStreamOptions()
            {
                Access = FileAccess.Read,
                Share = FileShare.ReadWrite,
                Mode = FileMode.OpenOrCreate
            };

            using FileStream openFileWithFileClassUsingFileStreamOptions = File.Open("myFileTwentyTwo.txt", fileStreamOptions);
            openFileWithFileClassUsingFileStreamOptions.Dispose();
            File.Delete("myFileTwentyTwo.txt");

            //Open a file with FileStreamOptions using FileInfo
            using FileStream openFileWithFileInfoClassUsingFileStreamOptions = fileInfo.Open(fileStreamOptions);
            openFileWithFileInfoClassUsingFileStreamOptions.Close();
            openFileWithFileInfoClassUsingFileStreamOptions.Dispose();
            
            return (openFileWithFileClass, result);
        }

        public static (FileStream, FileStream) OpenReadFile()
        {
            //Create a read-only file stream with static File.OpenRead()
            using FileStream openReadFileResult = File.Create("sampleReadOnlyFileTwo.txt");
            openReadFileResult.Dispose();
            File.Delete("myFileOne.txt");

            //Create a read-only file stream with instance FileInfo.OpenRead()
            FileInfo fileInfo = new("myFileTwo.txt");

            using FileStream openReadFileInfoResult = fileInfo.Create();
            openReadFileInfoResult.Dispose();
            fileInfo.Delete();

            return (openReadFileInfoResult, openReadFileResult);
        }

        public static (FileStream, FileStream) OpenWriteFile()
        {
            FileInfo fileInfo = new("myFileFourteen.txt");

            //Create a write-only file stream with static File.OpenWrite()
            using FileStream openWriteFileResult = File.OpenWrite("myFileFive.txt");
            openWriteFileResult.Dispose();
            File.Delete("myFileFive.txt");

            //Create a write-only file stream with instance FileInfo.OpenWrite()
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
            sr.ToString();
                Console.WriteLine(sr.ToString());
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
