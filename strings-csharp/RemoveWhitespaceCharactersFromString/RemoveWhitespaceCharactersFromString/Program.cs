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
var resultTrim = RemoveWhitespaceMethods.RemoveLeadingAndTrailingWhitespacesUsingTrim(sourceTrim);
Console.WriteLine(resultTrim); //prints 'John Doe'

//split+join
var sourceSplitJoin= " \t Hello World ";
var resultSplitJoin = RemoveWhitespaceMethods.RemoveWhitespacesUsingSplitJoin(sourceSplitJoin);
Console.WriteLine(resultSplitJoin); //prints 'HelloWorld'

//string builder
var sourceStringBuilder = " Hello World! \r\n";
var resultStringBuilder = RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(sourceStringBuilder);
Console.WriteLine(resultStringBuilder); //prints "HelloWorld!"

