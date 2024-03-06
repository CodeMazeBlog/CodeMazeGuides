using HowToCalculateADirectorySize;

var sizeOne = DirectorySizeCalculator.GetSizeWithRecursion(new DirectoryInfo(@"C:\Public\CM-Demos\Test"));
var sizeTwo = DirectorySizeCalculator.GetSizeByIteration(@"C:\Public\CM-Demos\Test");
var sizeThree = DirectorySizeCalculator.GetSizeByParallelProcessing(new DirectoryInfo(@"C:\Public\CM-Demos\Test"), true);

Console.WriteLine($"The directory has {sizeOne}bytes worth of files");
Console.WriteLine($"The directory has {sizeTwo}bytes worth of files");
Console.WriteLine($"The directory has {sizeThree}bytes worth of files");
