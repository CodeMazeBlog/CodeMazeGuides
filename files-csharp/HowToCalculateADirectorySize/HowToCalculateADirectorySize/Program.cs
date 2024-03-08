using HowToCalculateADirectorySize;
string resourceFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shared");

var sizeOne = DirectorySizeCalculator.GetSizeWithRecursion(new DirectoryInfo(resourceFolderPath));
var sizeTwo = DirectorySizeCalculator.GetSizeByIteration(resourceFolderPath);
var sizeThree = DirectorySizeCalculator.GetSizeByParallelProcessing(new DirectoryInfo(resourceFolderPath), true);

Console.WriteLine($"The directory has {sizeOne}bytes worth of files");
Console.WriteLine($"The directory has {sizeTwo}bytes worth of files");
Console.WriteLine($"The directory has {sizeThree}bytes worth of files");
