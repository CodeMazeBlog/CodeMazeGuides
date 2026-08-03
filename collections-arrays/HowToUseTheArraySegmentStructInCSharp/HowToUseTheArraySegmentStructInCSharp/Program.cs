// CREATING ARRAY SEGMENTS
string[] cities = ["Atlanta", "Belgrade", "Warsaw", "Berlin", "Tokyo", "London", "Cairo", "Sydney"];

Console.WriteLine("Creating array segment");
Console.WriteLine($"Original array: {cities.Length} elements");
var segment = new ArraySegment<string>(cities, 2,5);
Console.WriteLine($"Array view: {segment.Count} elements");
Console.WriteLine();

Console.WriteLine("Delimiting the entire array");
Console.WriteLine($"Original array: {cities.Length} elements");
var arraySegment = new ArraySegment<string>(cities);
Console.WriteLine($"Array view: {arraySegment.Count} elements");
Console.WriteLine();

// RETRIEVING ELEMENTS
Console.WriteLine("Retrieving an element from an array segment");
Console.WriteLine($"Element at index 3: {segment[3]}");
Console.WriteLine();

// ITERATING OVER THE ELEMENTS OF AN ARRAY SEGMENT
Console.WriteLine("Iterating over the elements of an array segment using the for loop");

for (int i = 0; i < segment.Count; i++)
    Console.WriteLine(segment[i]);
Console.WriteLine();

Console.WriteLine("Iterating over the elements of an array segment using the foreach loop");
foreach (var element in segment)
    Console.WriteLine(element);
Console.WriteLine();

// ARRAY SEGMENT PROPERTIES
Console.WriteLine("The original array accessed using the Array property:");
var originalArray = segment.Array;
for (int i = 0; i < originalArray?.Length; i++)
    Console.WriteLine(originalArray[i]);
Console.WriteLine();

Console.Write("The number of elements in the array segment: ");
var numberOfElements = segment.Count;
Console.WriteLine(numberOfElements);
Console.WriteLine();

Console.Write("The offset of the segment: ");
var offset = segment.Offset;
Console.WriteLine(offset);
Console.WriteLine();

Console.WriteLine("Creating an empty segment...");
var emptySegment = ArraySegment<string>.Empty;
Console.WriteLine($"The segment contains {emptySegment.Count} elements.");
Console.WriteLine();

// COMPARING ARRAY SEGMENTS
var segment1 = new ArraySegment<string>(cities, 2, 5);
var segment2 = new ArraySegment<string>(cities, 2, 5);
var segment3 = new ArraySegment<string>(cities, 3, 5);

Console.WriteLine("Comparing identical array segments");
Console.WriteLine($"Segments 1 and 2 are equal: {segment1 == segment2}");

Console.WriteLine("Comparing different array segments");
Console.WriteLine($"Segments 1 and 3 are equal: {segment1 == segment3}");
Console.WriteLine();

// SLICING AN ARRAY SEGMENT
Console.WriteLine("Slicing an array segment");
Console.WriteLine("The segment contains the following elements:");
foreach (var element in segment)
    Console.Write(element + " ");
var slice1 = segment.Slice(2);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Slice 1 contains the following elements:");
foreach (var element in slice1)
    Console.Write(element + " ");
Console.WriteLine();

var slice2 = segment.Slice(2, 2);

Console.WriteLine();
Console.WriteLine("Slice 2 contains the following elements:");
foreach (var element in slice2)
    Console.Write(element + " ");
Console.WriteLine();

var slice3 = segment[1..3];

Console.WriteLine();
Console.WriteLine("Slice 3 contains the following elements:");
foreach (var element in slice3)
    Console.Write(element + " ");
Console.WriteLine();
Console.WriteLine();

// RELATIONSHIPS BETWEEN ARRAY AND ARRAY SEGMENT
Console.WriteLine("Modifying an element of an array segment");
Console.WriteLine("Original array:");
foreach (var element in cities)
    Console.Write(element + " ");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Segment:");
foreach (var element in segment)
    Console.Write(element + " ");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Modifying an element in the segment...");
segment[2] = "Kyoto";
Console.WriteLine("Modified segment:");
foreach (var element in segment)
    Console.Write(element + " ");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Original array:");
foreach (var element in cities)
    Console.Write(element + " ");
Console.WriteLine();
Console.WriteLine();

Console.WriteLine("Relationships between indices");
for (int i = segment.Offset; i < segment.Offset + segment.Count; i++)
    Console.WriteLine(segment.Array?[i]);