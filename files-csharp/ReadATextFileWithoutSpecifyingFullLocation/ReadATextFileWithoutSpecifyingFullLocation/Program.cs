using ReadATextFileWithoutSpecifyingFullLocation;

const string fileName = @"CodeMaze.txt";

try
{
    var fileContent = ReadFileMethods.ReadFile(fileName);
    Console.WriteLine("File content:\n" + fileContent);
}
catch (IOException ex)
{
    Console.WriteLine("An error occurred while reading the file: " + ex.Message);
}