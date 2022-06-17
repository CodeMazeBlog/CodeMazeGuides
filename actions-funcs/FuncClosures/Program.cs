using System;
// See https://aka.ms/new-console-template for more information

// Func delegates Closures
Func<int, int> customMultiple = multipleBy();

Console.WriteLine(customMultiple(8));

Func<int, int> multipleBy()
{
    var num = 7;
    return n => n * num;
}
