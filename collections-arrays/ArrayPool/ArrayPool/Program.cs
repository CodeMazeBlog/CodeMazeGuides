using static ArrayPool.Methods;

var pool = GetDefaultArrayPool<int>();

var arraySize = 10;

var array = pool.Rent(arraySize);

for (var i = 0; i < arraySize; i++)
    array[i] = i * 2;

Console.WriteLine("Array elements:");

foreach (var value in array)
    Console.Write(value + " ");

pool.Return(array);