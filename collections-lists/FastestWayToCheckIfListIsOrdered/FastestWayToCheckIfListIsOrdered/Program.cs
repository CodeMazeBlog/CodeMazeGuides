using System.Buffers;
using BenchmarkDotNet.Running;
using FastestWayToCheckIfListIsOrdered;

BenchmarkRunner.Run<Benchmarks>();
return;

List<Employee> employees = [
    new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
    new Employee("Danniel", new DateTime(2000, 3, 2), 2_500),
    new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
    new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
];

var areOrdered = ListOrderValidator.IsOrderedUsingForLoop(employees);

areOrdered = ListOrderValidator.IsOrderedUsingArraySort(employees, ArrayPool<Employee>.Shared);

areOrdered = ListOrderValidator.IsOrderedUsingEnumerator(employees);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithSequenceEqual(employees);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithOrder(employees);

areOrdered = ListOrderValidator.IsOrderedUsingLinqWithZip(employees);

areOrdered = ListOrderValidator.IsOrderedUsingSpans(employees);

areOrdered = ListOrderValidator.IsOrderedUsingParallelFor(employees);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForWithSpans(employees);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitioned(employees);

areOrdered = ListOrderValidator.IsOrderedUsingParallelForPartitionedWithSpans(employees);
