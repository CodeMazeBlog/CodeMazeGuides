using static DeleteElementsFromAnArray.Methods;

var array = new int[] { 3, 4, 5, 3, 5, 7 };
var elementToDelete = 3;

Console.WriteLine("Initial Array: " + String.Join(",", array) + " Element to delete: "+ elementToDelete);
Console.WriteLine("Remove first instance of element: ");
Console.WriteLine("With ArrayCopy: " + String.Join(",", DeleteWithArrayCopy(array, elementToDelete)));
Console.WriteLine("With ArraySegment: " + String.Join(",", DeleteWithArraySegment(array, elementToDelete)));
Console.WriteLine("With Loop: " + String.Join(",", DeleteWithLoop(array, elementToDelete)));
Console.WriteLine("With BufferCopy: " + String.Join(",", DeleteWithBufferCopy(array, elementToDelete)));

Console.WriteLine("Remove every instance of the element: ");
Console.WriteLine("With FindAll: " + String.Join(",", DeleteWithFindAll(array, elementToDelete)));
Console.WriteLine("With Where: " + String.Join(",", DeleteWithWhere(array, elementToDelete)));
Console.WriteLine("With RemoveAll: " + String.Join(",", DeleteWithRemoveAll(array, elementToDelete)));
Console.WriteLine("With List: " + String.Join(",", DeleteWithList(array, elementToDelete)));
Console.WriteLine("With Pooled Array: " + String.Join(",", DeleteWithPooledArray(array, elementToDelete)));