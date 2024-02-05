using GetNumberOfLinesInTextFile;

const string FILE_NAME = "Sample.txt";

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingReadAllLinesMethod(FILE_NAME)}");

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingStreamReader(FILE_NAME)}");

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingReadLinesMethod(FILE_NAME)}");