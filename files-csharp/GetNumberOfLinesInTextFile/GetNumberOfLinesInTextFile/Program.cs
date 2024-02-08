using GetNumberOfLinesInTextFile;

const string FileName = "Sample.txt";

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingReadAllLinesMethod(FileName)}");

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingStreamReader(FileName)}");

Console.WriteLine($"Total Number of Lines in the text file: {FileHelper.CountLinesUsingReadLinesMethod(FileName)}");