//Example of Format Strings
var name = "John";
var formattedString = string.Format("Hello, {0}!", name);
Console.WriteLine(formattedString);

//Curly Brackets Escaping
var value = "World";
formattedString = string.Format("{{Hello, {0}!}}", value);
Console.WriteLine(formattedString);

//Dobble Quotes Escaping
var message = "Important message";
formattedString = string.Format("\"{0}\" is the message.", message);
Console.WriteLine(formattedString);

//Backslash Escaping
var path = @"C:\Program Files\";
formattedString = string.Format("The installation path is: {0}", path);
Console.WriteLine(formattedString);