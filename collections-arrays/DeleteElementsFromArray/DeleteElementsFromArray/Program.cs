using static DeleteElementsFromAnArray.Methods;

int[] array = [3, 4, 5, 3, 5, 7];
var elementToDelete = 3;

Console.WriteLine("Initial Array: " + string.Join(",", array) + " Element to delete: " + elementToDelete);
Console.WriteLine("Remove first instance of element: ");
Console.WriteLine("With ArrayCopy: " + string.Join(",", DeleteWithArrayCopy(array, elementToDelete)));
Console.WriteLine("With ArraySegment: " + string.Join(",", DeleteWithArraySegment(array, elementToDelete)));
Console.WriteLine("With Loop: " + string.Join(",", DeleteWithLoop(array, elementToDelete)));
Console.WriteLine("With BufferCopy: " + string.Join(",", DeleteWithBufferCopy(array, elementToDelete)));
Console.WriteLine("With CollectionExpression: " + string.Join(",", DeleteWithCollectionExpression(array, elementToDelete)));

var resizedArray = (int[])array.Clone();
DeleteWithLoopAndResize(ref resizedArray, elementToDelete);
Console.WriteLine("With Loop and Resize: " + string.Join(",", resizedArray));

Console.WriteLine("Remove every instance of the element: ");
Console.WriteLine("With FindAll: " + string.Join(",", DeleteWithFindAll(array, elementToDelete)));
Console.WriteLine("With Where: " + string.Join(",", DeleteWithWhere(array, elementToDelete)));
Console.WriteLine("With RemoveAll: " + string.Join(",", DeleteWithRemoveAll(array, elementToDelete)));
Console.WriteLine("With List: " + string.Join(",", DeleteWithList(array, elementToDelete)));
Console.WriteLine("With Pooled Array: " + string.Join(",", DeleteWithPooledArray(array, elementToDelete)));

Console.WriteLine("Remove the first element: " + string.Join(",", DeleteFirstElement(array)));
Console.WriteLine("Initial Array after all calls: " + string.Join(",", array));
