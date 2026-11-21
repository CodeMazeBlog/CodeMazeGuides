using static ArrayPool.Methods;

var pool = GetDefaultArrayPool<int>();

var arraySize = 10;

var array = pool.Rent(arraySize);

try
{
    for (var i = 0; i < arraySize; i++)
        array[i] = i * 2;

    Console.WriteLine("Array elements:");

    for (var i = 0; i < arraySize; i++)
        Console.Write(array[i] + " ");

    Console.WriteLine();
    Console.WriteLine($"Array size: {array.Length}");
}
finally
{
    pool.Return(array);
}

var nextArray = pool.Rent(arraySize);

Console.WriteLine("Next rented array:");

for (var i = 0; i < arraySize; i++)
    Console.Write(nextArray[i] + " ");

Console.WriteLine();

pool.Return(nextArray, clearArray: true);
