using BenchmarkDotNet.Running;
using FastestWayToCheckIfListIsOrdered;

List<Employee> employees = [
    new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
    new Employee("Danniel", new DateTime(2000, 3, 2), 2_500),
    new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
    new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
];

var areOrdered = ListOrderValidators.IsOrderedUsingForLoop(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingEnumerator(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingLinqWithSequenceEqual(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingLinqWithOrder(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingLinqWithZip(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingForLoopWithSpan(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingParallelFor(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingParallelForPartitioned(employees);
Console.WriteLine(areOrdered);

areOrdered = ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(employees);
Console.WriteLine(areOrdered);

BenchmarkRunner.Run<Benchmarks>();
