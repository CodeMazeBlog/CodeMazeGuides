using HowToCompareTwoListsThroughOneProperty.Models;

namespace HowToCompareTwoListsThroughOneProperty.Methods;

public static class ListCompareMethods
{
    public static List<Customer> ForEachMethod(List<Customer> customerList, List<Order> orderList) 
    { 
        var customersWithOrders = new List<Customer>();

        foreach (var customer in customerList)
        {
            foreach (var order in orderList)
            {
                if (customer.Id == order.CustomerId && !customersWithOrders.Contains(customer))
                {
                    customersWithOrders.Add(customer);
                }
            }
        }

        return customersWithOrders;
    }

    public static List<Customer> WhereAnyMethod(List<Customer> customerList, List<Order> orderList)
    {
        return customerList.Where(y => orderList.Any(z => z.CustomerId == y.Id)).ToList();
    }

    public static List<Customer> JoinMethod(List<Customer> customerList, List<Order> orderList)
    {
        var customersWithOrders = (from customer in customerList
                                   where orderList.Any(order => customer.Id == order.CustomerId)
                                   select customer
                                   ).ToList();

        return customersWithOrders;
    }

    public static List<Customer> HashSetMethod(List<Customer> customerList, List<Order> orderList)
    {
        var customerIds = orderList.Select(i => i.CustomerId).ToHashSet();

        return customerList.Where(i => customerIds.Contains(i.Id)).ToList();
    }

    public static List<Customer> JoinListMethod(List<Customer> customerList, List<Order> orderList)
    {
        return customerList.Join(
                orderList,
                customer => customer.Id,
                order => order.CustomerId,
                (customer, order) => customer
            ).Distinct().ToList();
    }
}
