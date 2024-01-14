// See https://aka.ms/new-console-template for more information

using App;

var names = CollectionExpressions.Names;
var hashSet = CollectionExpressions.CreateHashSetUsingNewExpressionSyntax();

foreach (var item in hashSet) Console.WriteLine(item);

foreach (var name in names) Console.WriteLine(name);

var arrayCreationWithSpreadOperator = CollectionExpressions.CreateNewArrayUsingSpreadOperator([1, 2, 3],
    [4, 5, 6], [7, 8, 9]);

foreach (var item in arrayCreationWithSpreadOperator) Console.WriteLine(item);

var arrayCreationWithSpreadOperatorWithAdditionalItems =
    CollectionExpressions.CreateNewArrayUsingSpreadOperatorWithAdditionalItems([1, 2, 3],
        [4, 5, 6], [7, 8, 9]);

foreach (var item in arrayCreationWithSpreadOperatorWithAdditionalItems) Console.WriteLine(item);

var jaggedArray = CollectionExpressions.CreateJaggedArray();

foreach (var item in jaggedArray)
{
    foreach (var item2 in item)
    {
        Console.WriteLine(item2);
    }
}

var list = CollectionExpressions.CreateListUsingNewExpressionSyntax();

foreach (var item in list)
{
    Console.WriteLine(item);
}

var span = CollectionExpressions.CreateSpanUsingNewExpressionSyntax();

foreach (var item in span)
{
    Console.WriteLine(item);
}