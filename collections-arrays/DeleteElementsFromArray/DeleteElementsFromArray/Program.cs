using static DeleteElementsFromAnArray.Methods;

var array = new int[] { 3, 4, 5, 3, 5, 7 };
var elementToDelete = 3;

Console.WriteLine("Modified arrays with the following methods used: ");
Console.WriteLine("With FindAll: " + String.Join(",", DeleteWithFindAll(array, elementToDelete)));
Console.WriteLine("With Where: " + String.Join(",", DeleteWithWhere(array, elementToDelete)));
Console.WriteLine("With RemoveAll: " + String.Join(",", DeleteWithRemoveAll(array, elementToDelete)));
Console.WriteLine("With Loop: " + String.Join(",", DeleteWithLoop(array, elementToDelete)));