using System.Text;
using System.Text.RegularExpressions;




using RemoveWhitespaceCharactersFromString;
//regex
var sourceRegex = " \t hello worl d";
var resultRegex = RemoveWhitespaceMethods.RemoveWhitespacesUsingRegex(sourceRegex);
Console.WriteLine(resultRegex); // prints 'helloworld'

//linq
var sourceLinq = "hello \t world\r\n123";
var resultLinq = RemoveWhitespaceMethods.RemoveWhitespacesUsingLinq(sourceLinq);
Console.WriteLine(resultLinq); //prints 'helloworld123'

//replace
var sourceReplace = " Hello World!";
var resultReplace = RemoveWhitespaceMethods.RemoveWhitespacesUsingReplace(sourceReplace);
Console.WriteLine(resultReplace); // prints 'HelloWorld!'

//trim
var sourceTrim = " \t John Doe ";
var resultTrim = RemoveWhitespaceMethods.RemoveWhitespacesUsingTrim(sourceTrim);
Console.WriteLine(resultTrim); //prints 'John Doe'

//string builder
var sourceStringBuilder = " Hello World! \r\n";
var resultStringBuilder = RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(sourceStringBuilder);
Console.WriteLine(resultStringBuilder); //prints "HelloWorld!"

