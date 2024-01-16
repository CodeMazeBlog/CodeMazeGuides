using HowToUseTheArraySegmentStructInCSharp;

// CREATING ARRAY SEGMENTS
string[] cities = ["Atlanta", "Belgrade", "Warsaw", "Berlin", "Tokyo", "London", "Cairo", "Sydney"];

Console.WriteLine("Creating array segment");
Console.WriteLine($"Original array: {cities.Length} elements");
Console.WriteLine($"Array view: {Utilities.GetArraySegmentLength(cities, 2, 5)} elements");
Console.WriteLine();

Console.WriteLine("Delimiting the entire array");
Console.WriteLine($"Original array: {cities.Length} elements");
Console.WriteLine($"Array view: {Utilities.GetArraySegmentLength(cities)} elements");
Console.WriteLine();

// RETRIEVING ELEMENTS
Console.WriteLine("Retrieving an element from an array segment");
var segment = new ArraySegment<string>(cities, 2, 5);
Console.WriteLine($"Element at index 3: {Utilities.RetrieveElement(segment, 3)}");
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
var originalArray = Utilities.GetOriginalArray(segment);
for (int i = 0; i < originalArray?.Length; i++)
    Console.WriteLine(originalArray[i]);
Console.WriteLine();

Console.Write("The number of elements in the array segment: ");
var numberOfElements = Utilities.CountElementsInSegment(segment);
Console.WriteLine(numberOfElements);
Console.WriteLine();

Console.Write("The offset of the segment: ");
var offset = Utilities.GetOffset(segment);
Console.WriteLine(offset);
Console.WriteLine();

Console.WriteLine("Creating an empty segment...");
var emptySegment = Utilities.CreateEmptySegment<string>();
Console.WriteLine($"The segment contains {emptySegment.Count} elements.");
Console.WriteLine();

// COMPARING ARRAY SEGMENTS
var segment1 = new ArraySegment<string>(cities, 2, 5);
var segment2 = new ArraySegment<string>(cities, 2, 5);
var segment3 = new ArraySegment<string>(cities, 3, 5);

var areEqual1And2 = Utilities.CompareArraySegments(segment1, segment2);
var areEqual1And3 = Utilities.CompareArraySegments(segment1, segment3);

Console.WriteLine("Comparing identical array segments");
var negation1 = areEqual1And2 ? "" : "not ";
Console.WriteLine($"Segments 1 and 2 are {negation1}equal.");
Console.WriteLine();

Console.WriteLine("Comparing different array segments");
var negation2 = areEqual1And3 ? "" : " not ";
Console.WriteLine($"Segments 1 and 3 are{negation2}equal.");
Console.WriteLine();

Console.WriteLine($"Segments 1 and 2 are equal: {segment1 == segment2}");
Console.WriteLine($"Segments 1 and 3 are equal: {segment1 == segment3}");
Console.WriteLine();

// SLICING AN ARRAY SEGMENT
Console.WriteLine("Slicing an array segment");
Console.WriteLine("The segment contains the following elements:");
foreach (var element in segment)
    Console.Write(element + " ");
var slice1 = Utilities.GetSegmentSlice(segment, 2);

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Slice 1 contains the following elements:");
foreach (var element in slice1)
    Console.Write(element + " ");
Console.WriteLine();

var slice2 = Utilities.GetSegmentSlice(segment, 2, 2);

Console.WriteLine();
Console.WriteLine("Slice 2 contains the following elements:");
foreach (var element in slice2)
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
Utilities.ModifySegmentElement(segment, 2, "Kyoto");
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