using SaveListToFileInCSharp;

var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
var fileName = "Animals.txt";
var path = Path.Combine(docPath, fileName);

var fileWriter = new ListToFileWriter();

//Using the StreamWriter class
//Write all animals to file
var animals = new List<string> { "Dog", "Cat", "Parrot" };
fileWriter.WriteToFileWithStreamWriter(path, animals);

//Asynchronous version
await fileWriter.WriteToFileWithStreamWriterAsync(path, animals);

//Append new animal to an existing file
var newAnimals = new List<string> { "Hamster" };
fileWriter.AppendToFileWithStreamWriter(path, animals);

//Using the File class in C#
File.WriteAllLines(path, animals);
File.AppendAllLines(path, newAnimals);

//Asynchronous version
await File.WriteAllLinesAsync(path, animals);
await File.AppendAllLinesAsync(path, newAnimals);