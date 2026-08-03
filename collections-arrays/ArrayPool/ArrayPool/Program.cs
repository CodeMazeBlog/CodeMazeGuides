using static ArrayPool.Methods;

var pool = GetDefaultArrayPool<int>();

var arraySize = 10;

var array = pool.Rent(arraySize);

for (var i = 0; i < arraySize; i++)
    array[i] = i * 2;

Console.WriteLine("Array elements:");

for (var i = 0; i < arraySize; i++) 
    Console.Write(array[i] + " ");

Console.WriteLine($"Array size: {array.Length}");

pool.Return(array);