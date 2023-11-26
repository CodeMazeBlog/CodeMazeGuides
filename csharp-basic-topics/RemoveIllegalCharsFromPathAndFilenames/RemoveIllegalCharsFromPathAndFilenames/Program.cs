HashSet<char> invalidPathChars = new HashSet<char>(Path.GetInvalidPathChars());
HashSet<char> invalidFilenameChars = new HashSet<char>(Path.GetInvalidFileNameChars());

List<string> pathList = new List<string>
{
    "A://ValidPath/SomeFolder/Invalid??File??Broken.nah",
    "B:\\InValid:|:Path/",
    "C://IsThisavalidpath??\0/",
    "D://Thi*IsIN\nv00ALID/<</",
    "E://Users/ValidPath/docs/Storyboard_2023.docx",
    "F://Users/Photos/Cats/FluffyCat.png",
    "G://Inv@7**\\*lidPath/",
    "H://Test/This<IS>Ano<>therInvalidPath\r/",
    "I://ProgramFiles/SomeApplication/:Invalid:Filename.txt"
};

// Checking for invalid paths
Console.WriteLine("Conventional Logic Result:");
foreach (var str in StringMethods.CheckForInvalid(pathList, invalidPathChars)) { Console.WriteLine(str); }

Console.WriteLine();
Console.WriteLine("LINQ Result:");
foreach (var str in StringMethods.CheckForInvalidLINQ(pathList, invalidPathChars)) { Console.WriteLine(str); }

Console.WriteLine();
Console.WriteLine("LINQ - Header Format Result:");
foreach (var str in StringMethods.CheckForInvalidLINQHeader(pathList, invalidPathChars)) { Console.WriteLine(str); }

Console.WriteLine();
Console.WriteLine("RegEx Result:");
foreach (var str in StringMethods.CheckForInvalidRegEx(pathList, invalidPathChars)) { Console.WriteLine(str); }

// Checking for invalid filenames
IEnumerable<string> invalidFilenameList = StringMethods.CheckForInvalidLINQ(StringMethods.GetFileNames(pathList), invalidFilenameChars);

// Removing invalid characters from filenames
List<string> validFilenameList = new List<string>();

Console.WriteLine();
Console.WriteLine("Invalid Filenames:");
foreach (var path in invalidFilenameList) 
{ 
    validFilenameList.Add(StringMethods.RemoveInvalidChars(path, invalidFilenameChars));
    Console.WriteLine(path);
}
// Process filenames to make valid
Console.WriteLine();
Console.WriteLine("Valid Filenames after processing:");
foreach (var path in validFilenameList) {  Console.WriteLine(path); }