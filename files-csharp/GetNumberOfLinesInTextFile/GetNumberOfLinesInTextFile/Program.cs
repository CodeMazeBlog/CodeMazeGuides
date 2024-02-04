using GetNumberOfLinesInTextFile;

const string FILE_NAME = "Sample.txt";

Console.WriteLine(FileHelper.CountLinesUsingReadAllLinesMethod(FILE_NAME));

Console.WriteLine(FileHelper.CountLinesUsingStreamReader(FILE_NAME));

Console.WriteLine(FileHelper.CountLinesUsingReadLinesMethod(FILE_NAME));