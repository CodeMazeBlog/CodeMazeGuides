using GetClassNameInCSharp;

// Creating an instance of Car class
Car myCar = new();

// Retrieving class name from instance methods of Car
Console.WriteLine("Retrieving class name using different methods in Car instance:");
Console.WriteLine("Using GetType: " + myCar.DisplayClassNameWithGetType());
Console.WriteLine("Using typeof: " + myCar.DisplayClassNameWithTypeOf());
Console.WriteLine("Using nameof: " + myCar.DisplayClassNameWithNameOf());
Console.WriteLine("Using Reflection: " + myCar.DisplayClassNameWithReflection());

Console.WriteLine();

// Retrieving class name from outside methods of Car class
Console.WriteLine("Retrieving class name from outside the Car instance:");
Console.WriteLine("Using GetType: " + myCar.GetType().Name);
Console.WriteLine("Using typeof: " + typeof(Car).Name);
Console.WriteLine("Using nameof: " + nameof(Car));

Console.WriteLine();

// Retrieving class name from static methods of CarInfo
Console.WriteLine("Retrieving class name using different methods in static CarInfo class:");
Console.WriteLine("Using typeof: " + CarInfo.DisplayClassNameWithTypeOf());
Console.WriteLine("Using nameof: " + CarInfo.DisplayClassNameWithNameOf());

Console.WriteLine();

// Retrieving class name from outside static class CarInfo
Console.WriteLine("Retrieving class name from outside static CarInfo class:");
Console.WriteLine("Using typeof: " + typeof(CarInfo).Name);
Console.WriteLine("Using nameof: " + nameof(CarInfo));