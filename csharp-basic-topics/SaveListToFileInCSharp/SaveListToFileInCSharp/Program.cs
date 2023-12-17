var docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
var fileName = "Animals.txt";
var path = Path.Combine(docPath, fileName);

//Write all animals to file
var animals = new List<string> { "Dog", "Cat", "Parrot" };

using (var sw = new StreamWriter(path))
{
    foreach (var animal in animals)
    {
        sw.WriteLine(animal);
    }
}

//Asynchronous version
await using (var sw = new StreamWriter(path))
{
    foreach (var animal in animals)
    {
        await sw.WriteLineAsync(animal);
    }
}

//Append new animal to an existing file
var newAnimals = new List<string> { "Hamster" };

using (var sw = new StreamWriter(path, true))
{
    foreach (var animal in newAnimals)
    {
        sw.WriteLine(animal);
    }
}

//Using the File class in C#
File.WriteAllLines(path, animals);
File.AppendAllLines(path, newAnimals);

//Asynchronous version
await File.WriteAllLinesAsync(path, animals);