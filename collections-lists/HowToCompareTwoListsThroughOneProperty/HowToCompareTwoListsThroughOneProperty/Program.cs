using HowToCompareTwoListsThroughOneProperty.Methods;
using HowToCompareTwoListsThroughOneProperty.Models;

var customers = new List<Customer>()
{
    new() { Id = 1, Firstname = "Alice", Surname = "Smith"},
    new() { Id = 2, Firstname = "John", Surname = "Terry"},
    new() { Id = 3, Firstname = "Fred", Surname = "Staton"}
};

var orders = new List<Order>()
{
    new () {CustomerId = 1, OrderId = 101},
    new () {CustomerId = 2, OrderId = 102},
    new () {CustomerId = 2, OrderId = 103}
};

var customerWithOrders = ListCompareMethods.ForEachMethod(customers, orders);
Console.WriteLine(string.Join(',',customerWithOrders.Select(i=>i.Firstname)));

var customerWithOrdersB = ListCompareMethods.WhereAnyMethod(customers, orders);
Console.WriteLine(string.Join(',', customerWithOrdersB.Select(i => i.Firstname)));

var customerWithOrdersC = ListCompareMethods.JoinMethod(customers, orders);
Console.WriteLine(string.Join(',', customerWithOrdersC.Select(i => i.Firstname)));

var customerWithOrdersD = ListCompareMethods.HashSetMethod(customers, orders);
Console.WriteLine(string.Join(',', customerWithOrdersD.Select(i => i.Firstname)));

var customerWithOrdersE = ListCompareMethods.JoinListMethod(customers, orders);
Console.WriteLine(string.Join(',', customerWithOrdersE.Select(i => i.Firstname)));