using RemoveIllegalCharsFromPathAndFilenames;

HashSet<char> invalidPathChars = new HashSet<char>
{
    '|', '\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a',
    '\b', '\t', '\n', '\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0011',
    '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018',
    '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f'
};
HashSet<char> invalidFilenameChars = new HashSet<char>(invalidPathChars)
{
    '"', '<', '>', ':', '*', '?', '\\', '/'
};
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
foreach (var str in StringMethods.CheckForInvalidLINQQuerySyntax(pathList, invalidPathChars)) { Console.WriteLine(str); }

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
foreach (var path in validFilenameList) { Console.WriteLine(path); }