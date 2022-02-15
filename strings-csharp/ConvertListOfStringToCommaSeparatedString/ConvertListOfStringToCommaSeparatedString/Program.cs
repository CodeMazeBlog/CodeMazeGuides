using ConvertListOfStringToCommaSeparatedString;

var list = new SimpleList();
var commaSeparatedString = list.ConvertListOfStringsToCommaSeparatedString(); 
Console.WriteLine(commaSeparatedString); // Output Hello,From,Code Maze   

var complexlist = new ComplexList();
var employeeNames = complexlist.ConvertListOfStringsToCommaSeparatedString(); 
Console.WriteLine(employeeNames); // Output Sarah,Eric
