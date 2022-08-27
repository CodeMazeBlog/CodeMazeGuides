Console.WriteLine("Press 'Enter' to exit\n");
Console.WriteLine($"Directory To Monitor: { FileUtil.DirectoryToMonitor }");

var fileName = $"TEST-{DateTime.Now.ToString("yyyy-dd-M HH-mm-ss")}.txt";
var updatedFileName = $"UPDATED-{DateTime.Now.ToString("yyyy-dd-M HH-mm-ss")}.txt";
var contents = new string[] { "Hello" };
var updatedContents = new string[] { "Hello World" };

using var manager = new TextFileManager(FileUtil.DirectoryToMonitor);
manager.Create(fileName, contents);
manager.Update(fileName, updatedContents);
manager.Rename(fileName, updatedFileName);
manager.Delete(updatedFileName);

Console.ReadLine();
