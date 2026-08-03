using HowToFilterAListBasedOnAnotherListInCSharp;

List<int> intsToFilter = [1, 2, 3, 4, 4, 4, 5, 6, 7, 7, 8, 8, 9];
List<int> filteringIntList = [4, 4, 7, 9, 10];

List<int> filteredContainedInts;
List<int> filteredNotContainedInts;

Console.WriteLine("LOOPS");
Console.WriteLine("Elements from list 1 that are contained in list 2:");
filteredContainedInts = Utilities.FilterContainedUsingLoop(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();
Console.WriteLine("Elements from list 1 that are not contained in list 2:");
filteredNotContainedInts = Utilities.FilterNotContainedUsingLoop(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredNotContainedInts));
Console.WriteLine();

Console.WriteLine("WHERE METHOD");
Console.WriteLine("Elements from list 1 that are contained in list 2:");
filteredContainedInts = Utilities.FilterContainedUsingWhere(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();
Console.WriteLine("Elements from list 1 that are not contained in list 2:");
filteredContainedInts = Utilities.FilterNotContainedUsingWhere(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();

Console.WriteLine("DUPLICATES");
Console.WriteLine("Unique elements from list 1 that are contained in list 2:");
filteredContainedInts = Utilities.FilterContainedUnique(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();

Console.WriteLine("EXCEPT METHOD");
Console.WriteLine("Elements from list 1 that are not contained in list 2:");
filteredContainedInts = Utilities.FilterNotContainedUsingExcept(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();

Console.WriteLine("DIFFERENT TYPES");
List<string> stringsToFilter = ["2", "5", "10", "20"];
filteringIntList = [5, 8, 12, 20];
List<string> filteredContainedStrings;
Console.WriteLine("Elements from list 1 that have their counterparts in list 2:");
filteredContainedStrings = Utilities.FilterStringsByInts(stringsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedStrings));
Console.WriteLine();

Console.WriteLine("CUSTOM CRITERIA");
List<string> animalsToFilter = ["cat", "fox", "horse", "donkey", "snake", "lion"];
List<int> filteringLengthList = [3, 5];
List<string> filteredAnimalNames;
Console.WriteLine("Animals from list 1 whose names' lengths are elements of list 2:");
filteredAnimalNames = Utilities.FilterAnimalNamesByLengths(animalsToFilter, filteringLengthList);
Console.WriteLine(Utilities.PrintList(filteredAnimalNames));
Console.WriteLine();

Console.WriteLine("COMPLEX OBJECTS");
List<Student> studentsToFilter =
[
    new Student { Id = 1, Name = "Alice Straw", SchoolId = 1, City = "Munich" },
    new Student { Id = 2, Name = "Mike McAllen", SchoolId = 1, City = "Munich" },
    new Student { Id = 3, Name = "Bettany Kelly", SchoolId = 2, City = "Essen" },
    new Student { Id = 4, Name = "Sue Heck", SchoolId = 2, City = "Wuppertal" },
    new Student { Id = 5, Name = "Jake Millner", SchoolId = 2, City = "Mainz" },
    new Student { Id = 6, Name = "Allen Claude", SchoolId = 3, City = "Hamburg" }
];
List<School> schoolsToFilter =
[
    new School { Id = 1, City = "Munich" },
    new School { Id = 2, City = "Essen" },
    new School { Id = 3, City = "Hamburg" }
];
List<Student> filteredStudents;
Console.WriteLine("Students from list 1 that attend a school in their city from list 2:");
filteredStudents = Utilities.FilterStudentsBySchoolCity(studentsToFilter, schoolsToFilter);
Console.WriteLine(Utilities.PrintList(filteredStudents));
Console.WriteLine();

Console.WriteLine("SPECIFIC PROPERTIES");
List<int> schoolIds = [1, 3];
Console.WriteLine("Names of students from list 1 that attend schools with IDs from list 2:");
List<string> filteredStudentNames = Utilities.FilterStudentsWithProperties(studentsToFilter, schoolIds);
Console.WriteLine(Utilities.PrintList(filteredStudentNames));
Console.WriteLine();

Console.WriteLine("UPDATING PROPERTIES");
List<int> studentIds = [4, 6];
Console.WriteLine("Updating the City property of the students from list 1 with IDs from list 2:");
Utilities.UpdateCityProperty(studentsToFilter, studentIds);
Console.WriteLine(Utilities.PrintList(studentsToFilter));
Console.WriteLine();

Console.WriteLine("HASHSET");
intsToFilter = [2, 4, 6, 8, 10, 16, 20, 28, 40, 45];
filteringIntList = [0, 10, 20, 30, 40, 50];
Console.WriteLine("Elements from list 1 that are contained in list 2:");
filteredContainedInts = Utilities.FilterUsingHashSet(intsToFilter, filteringIntList);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();

Console.WriteLine("MASKS");
intsToFilter = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15];
List<bool> mask = [true, false, false, false];
Console.WriteLine("Elements from list 1 that correspond to true in the mask:");
filteredContainedInts = Utilities.FilterUsingMask(intsToFilter, mask);
Console.WriteLine(Utilities.PrintList(filteredContainedInts));
Console.WriteLine();
