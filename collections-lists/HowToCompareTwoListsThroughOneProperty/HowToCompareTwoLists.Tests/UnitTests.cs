namespace HowToCompareTwoLists.Tests;

public class Tests
{
    private List<Customer> _threeCustomers;
    private List<Order> _threeOrders;
    private List<Order> _twoOrders;

    [SetUp]
    public void Setup()
    {
        _threeCustomers =
        [
            new() { Id = 1, Firstname = "CustomerFirstName1", Surname = "CustomerSurname1" },
            new() { Id = 2, Firstname = "CustomerFirstName2", Surname = "CustomerSurname2" },
            new() { Id = 3, Firstname = "CustomerFirstName3", Surname = "CustomerSurname3" }
        ];

        _threeOrders =
        [
            new() { CustomerId = 1, OrderId = 101 },
            new() { CustomerId = 2, OrderId = 102 },
            new() { CustomerId = 3, OrderId = 103 },
            new() { CustomerId = 1, OrderId = 104 }
        ];

        _twoOrders =
        [
            new() { CustomerId = 1, OrderId = 101 },
            new() { CustomerId = 2, OrderId = 102 }
        ];
    }

    [Test]
    public void GivenForeachMethod_WhenThreeCustomersWithThreeOrders_ThenReturnThreeCustomers()
    {
        var result = ListCompareMethods.ForEachMethod(_threeCustomers, _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(3));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.Contains(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenForeachMethod_WhenThreeCustomersWithTwoOrders_ThenReturnTwoCustomers()
    {
        var result = ListCompareMethods.ForEachMethod(_threeCustomers, _twoOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.DoesNotContain(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenForeachMethod_WhenNoOrders_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.ForEachMethod(_threeCustomers, []);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenForeachMethod_WhenNoCustomers_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.ForEachMethod([], _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenWhereAnyMethod_WhenThreeCustomersWithThreeOrders_ThenReturnThreeCustomers()
    {
        var result = ListCompareMethods.WhereAnyMethod(_threeCustomers, _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(3));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.Contains(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenWhereAnyMethod_WhenThreeCustomersWithTwoOrders_ThenReturnTwoCustomers()
    {
        var result = ListCompareMethods.WhereAnyMethod(_threeCustomers, _twoOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.DoesNotContain(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenWhereAnyMethod_WhenNoOrders_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.WhereAnyMethod(_threeCustomers, []);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenWhereAnyMethod_WhenNoCustomers_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.WhereAnyMethod([], _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenJoinMethod_WhenThreeCustomersWithThreeOrders_ThenReturnThreeCustomers()
    {
        var result = ListCompareMethods.JoinMethod(_threeCustomers, _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(3));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.Contains(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenJoinMethod_WhenThreeCustomersWithTwoOrders_ThenReturnTwoCustomers()
    {
        var result = ListCompareMethods.JoinMethod(_threeCustomers, _twoOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.DoesNotContain(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenJoinMethod_WhenNoOrders_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.JoinMethod(_threeCustomers, []);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenJoinMethod_WhenNoCustomers_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.JoinMethod([], _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenHashSetMethod_WhenThreeCustomersWithThreeOrders_ThenReturnThreeCustomers()
    {
        var result = ListCompareMethods.HashSetMethod(_threeCustomers, _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(3));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.Contains(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenHashSetMethod_WhenThreeCustomersWithTwoOrders_ThenReturnTwoCustomers()
    {
        var result = ListCompareMethods.HashSetMethod(_threeCustomers, _twoOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.DoesNotContain(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenHashSetMethod_WhenNoOrders_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.HashSetMethod(_threeCustomers, []);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenHashSetMethod_WhenNoCustomers_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.HashSetMethod([], _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenJoinListMethod_WhenThreeCustomersWithThreeOrders_ThenReturnThreeCustomers()
    {
        var result = ListCompareMethods.JoinListMethod(_threeCustomers, _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(3));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.Contains(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenJoinListMethod_WhenThreeCustomersWithTwoOrders_ThenReturnTwoCustomers()
    {
        var result = ListCompareMethods.JoinListMethod(_threeCustomers, _twoOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(2));

        CollectionAssert.Contains(result, _threeCustomers[0]);
        CollectionAssert.Contains(result, _threeCustomers[1]);
        CollectionAssert.DoesNotContain(result, _threeCustomers[2]);
    }

    [Test]
    public void GivenJoinListMethod_WhenNoOrders_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.JoinListMethod(_threeCustomers, []);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }

    [Test]
    public void GivenJoinListMethod_WhenNoCustomers_ThenReturnEmptyList()
    {
        var result = ListCompareMethods.JoinListMethod([], _threeOrders);

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Has.Count.EqualTo(0));
    }
}