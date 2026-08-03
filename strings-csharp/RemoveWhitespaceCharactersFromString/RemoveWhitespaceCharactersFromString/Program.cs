using RemoveWhitespaceCharactersFromString;

const string sourceHelloWorld = "\v\tHello World!\r\n";

//regex
var resultRegex = RemoveWhitespaceMethods.RemoveWhitespacesUsingStaticRegexClass(sourceHelloWorld);
Console.WriteLine(resultRegex); // prints 'HelloWorld!'

//linq with string concat
var resultLinqConcat = RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConcat(sourceHelloWorld);
Console.WriteLine(resultLinqConcat); //prints 'HelloWorld!'

//linq with string construct
var resultLinqConstruct = RemoveWhitespaceMethods.RemoveWhitespacesUsingLinqWithStringConstruct(sourceHelloWorld);
Console.WriteLine(resultLinqConstruct); //prints 'HelloWorld!'

//replace
var resultReplace = RemoveWhitespaceMethods.RemoveWhitespacesUsingReplace(sourceHelloWorld);
Console.WriteLine(resultReplace); // prints 'HelloWorld!'

//split+join
var resultSplitJoin = RemoveWhitespaceMethods.RemoveWhitespacesUsingSplitJoin(sourceHelloWorld);
Console.WriteLine(resultSplitJoin); //prints 'HelloWorld!'

//string builder
var resultStringBuilder = RemoveWhitespaceMethods.RemoveWhitespacesUsingStringBuilder(sourceHelloWorld);
Console.WriteLine(resultStringBuilder); //prints "HelloWorld!"

// array
var resultArray = RemoveWhitespaceMethods.RemoveWhitespacesUsingArray(sourceHelloWorld);
Console.WriteLine(resultArray); // prints "HelloWorld!"

//String.Trim
var resultTrim = RemoveWhitespaceMethods.TrimWhitespacesUsingStringTrim(sourceHelloWorld);
Console.WriteLine(resultTrim); //prints 'Hello World!'

// regex trim
var regexTrim = RemoveWhitespaceMethods.TrimWhitespacesUsingSourceGenRegex(sourceHelloWorld);
Console.Write(regexTrim); // prints 'Hello World!'