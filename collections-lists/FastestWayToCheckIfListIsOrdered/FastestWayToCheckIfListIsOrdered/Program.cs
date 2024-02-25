using System.Buffers;
using FastestWayToCheckIfListIsOrdered;

List<Employee> employees = [
    new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
    new Employee("Danniel", new DateTime(2000, 3, 2), 2_500),
    new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
    new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
];

var areOrdered = ListOrderValidator.IsOrderedUsingForLoop(employees);
Console.WriteLine(areOrdered);

var array = ArrayPool<Employee>.Shared.Rent(employees.Count);

areOrdered = ListOrderValidator.IsOrderedUsingArraySort(employees, array);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingEnumerator(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingSpans(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingParallelFor(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(employees);
Console.WriteLine(areOrdered);
