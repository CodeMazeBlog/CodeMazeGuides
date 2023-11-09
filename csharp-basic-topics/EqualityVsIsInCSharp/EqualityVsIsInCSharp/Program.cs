using File = EqualityVsIsInCSharp.File;

File jpgPhoto = new("path1");
File pdfFile = new("path2");

if (jpgPhoto == pdfFile)
{
    Console.WriteLine("The files are the same");
}
else
{
    Console.WriteLine("The files are NOT the same");
}

File wordFile = new("path3");

if (wordFile == null)
{
    Console.WriteLine("Word file does not exist");
}

Console.ReadLine();