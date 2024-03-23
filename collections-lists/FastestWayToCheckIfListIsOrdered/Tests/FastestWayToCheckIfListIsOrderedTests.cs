namespace Tests;

public class FastestWayToCheckIfListIsOrderedTests
{
    private static readonly List<Employee> OrderedEmployees =
    [
        new Employee("Jack", new DateTime(1998, 11, 1), 3_000),
        new Employee("Simon", new DateTime(1999, 4, 10), 3_000),
        new Employee("Daniel", new DateTime(2000, 3, 2), 2_500),
        new Employee("Maria", new DateTime(2001, 5, 23), 4_300),
        new Employee("Angel", new DateTime(2001, 7, 14), 1_900)
    ];

    private static readonly List<Employee> OutOfOrderEmployees =
    [
        new Employee("Alice", new DateTime(2003, 11, 1), 3_000),
        new Employee("Grace", new DateTime(1999, 4, 10), 3_000),
        new Employee("Henry", new DateTime(2000, 3, 2), 2_500),
        new Employee("Isabella", new DateTime(1998, 5, 23), 4_300),
        new Employee("Mario", new DateTime(2005, 7, 14), 1_900)
    ];

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingForLoop_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingForLoop(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingForLoop_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingForLoop(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingSpanSort_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingSpanSort(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingSpanSort_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingSpanSort(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingEnumerator_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingEnumerator(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingEnumerator_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingEnumerator(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingSpans_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingForLoopWithSpan(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingSpans_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingForLoopWithSpan(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqSequenceEqual_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingLinqWithSequenceEqual(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqSequenceEqual_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingLinqWithSequenceEqual(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqOrder_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingLinqWithOrder(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqOrder_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingLinqWithOrder(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingLinqZip_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingLinqWithZip(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingLinqZip_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingLinqWithZip(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelFor_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingParallelFor(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelFor_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingParallelFor(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingParallelForPartitioned(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelForPartitioned_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingParallelForPartitioned(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedEmployees_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeTrue()
    {
        ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(OrderedEmployees).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedEmployees_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeFalse()
    {
        ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(OutOfOrderEmployees).Should().BeFalse();
    }

    [Fact]
    public void GivenOrderedIntegers_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        var list = Enumerable.Range(0, Environment.ProcessorCount * 100).ToList();

        ListOrderValidators.IsOrderedUsingParallelForPartitioned(list).Should().BeTrue();
    }

    [Fact]
    public void
        GivenOrderedIntegersWithLengthOneOverProcessorCount_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        var list = Enumerable.Range(0, Environment.ProcessorCount + 1).ToList();

        ListOrderValidators.IsOrderedUsingParallelForPartitioned(list).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedIntegers_WhenCheckedUsingParallelForPartitioned_ThenShouldBeFalse()
    {
        var list = Enumerable.Repeat(42, Environment.ProcessorCount * 100).ToList();
        for (var i = 1; i < list.Count; ++i)
        {
            var temp = list[i];
            list[i] = temp - 2;

            ListOrderValidators.IsOrderedUsingParallelForPartitioned(list).Should().BeFalse();

            list[i] = temp;
        }
    }

    [Fact]
    public void GivenOrderedIntegers_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeTrue()
    {
        var list = Enumerable.Range(0, Environment.ProcessorCount * 100).ToList();

        ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(list).Should().BeTrue();
    }

    [Fact]
    public void
        GivenOrderedIntegersWithLengthOneOverProcessorCount_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeTrue()
    {
        var list = Enumerable.Range(0, Environment.ProcessorCount + 1).ToList();

        ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(list).Should().BeTrue();
    }

    [Fact]
    public void GivenUnorderedIntegers_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeFalse()
    {
        var list = Enumerable.Repeat(42, Environment.ProcessorCount * 100).ToList();
        for (var i = 1; i < list.Count; ++i)
        {
            var temp = list[i];
            list[i] = temp - 2;

            ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(list).Should().BeFalse();

            list[i] = temp;
        }
    }

    [Fact]
    public void GivenUnorderedIntegerLists_WhenCheckedUsingParallelForPartitioned_ThenShouldBeFalse()
    {
        for (var i = 1; i < 8; ++i)
        {
            var list = Enumerable.Range(0, Environment.ProcessorCount * i + 1).ToList();
            for (var j = 1; j < list.Count; ++j)
            {
                var temp = list[j];
                list[j] = temp - 2;

                ListOrderValidators.IsOrderedUsingParallelForPartitioned(list).Should().BeFalse();

                list[j] = temp;
            }
        }
    }

    [Fact]
    public void GivenOrderedIntegerLists_WhenCheckedUsingParallelForPartitioned_ThenShouldBeTrue()
    {
        for (var i = 1; i < 8; ++i)
        {
            var list = Enumerable.Range(0, Environment.ProcessorCount * i + 1).ToList();

            ListOrderValidators.IsOrderedUsingParallelForPartitioned(list).Should().BeTrue();
        }
    }

    [Fact]
    public void GivenUnorderedIntegerLists_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeFalse()
    {
        for (var i = 1; i < 8; ++i)
        {
            var list = Enumerable.Range(0, Environment.ProcessorCount * i + 1).ToList();
            for (var j = 1; j < list.Count; ++j)
            {
                var temp = list[j];
                list[j] = temp - 2;

                ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(list).Should().BeFalse();

                list[j] = temp;
            }
        }
    }

    [Fact]
    public void GivenOrderedIntegerLists_WhenCheckedUsingParallelForPartitionedWithSpans_ThenShouldBeFalse()
    {
        for (var i = 1; i < 8; ++i)
        {
            var list = Enumerable.Range(0, Environment.ProcessorCount * i + 1).ToList();

            ListOrderValidators.IsOrderedUsingParallelForPartitionedWithSpans(list).Should().BeTrue();
        }
    }
}