using HowToCalculateADirectorySize;

DirectoryInfo directory = new(@"");
//var size = DirectorySizeCalculator.GetSizeWithRecursion(directory);
//var size = DirectorySizeCalculator.GetSizeByParallelProcessing(directory, true);
var size = DirectorySizeCalculator.GetSizeByIteration(@"");

Console.WriteLine($"The {directory.Name} directory has {size}bytes worth of files");