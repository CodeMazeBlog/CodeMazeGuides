using HowToCalculateADirectorySize;

//DirectoryInfo directory = new(@"");
//var size = DirectorySizeCalculator.GetSizeWithRecursion(directory);
//var size = DirectorySizeCalculator.GetSizeByParallelProcessing(directory, true);
var size = DirectorySizeCalculator.GetSizeByIteration(@"C:\Users\racho\Desktop\Nothing");

Console.WriteLine($"The directory has {size}bytes worth of files");