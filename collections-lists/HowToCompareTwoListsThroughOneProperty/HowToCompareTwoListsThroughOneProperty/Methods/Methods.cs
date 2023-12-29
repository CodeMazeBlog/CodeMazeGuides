using HowToCompareTwoListsThroughOneProperty.Models;

namespace HowToCompareTwoListsThroughOneProperty.Methods;

public class Methods
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

    public static List<Customer> WhereAnyMethod(IEnumerable<Customer> customerList, IEnumerable<Order> orderList)
    {
        return customerList.Where(y => orderList.Any(z => z.CustomerId == y.Id)).ToList();
    }

    public static List<Customer> JoinMethod(IEnumerable<Customer> customerList, IEnumerable<Order> orderList)
    {
        var customersWithOrders = (from customer in customerList
                                   where orderList.Any(order => customer.Id == order.CustomerId)
                                   select customer
                                   ).ToList();

        return customersWithOrders;
    }

    public static List<Customer> HashSetMethod(IEnumerable<Customer> customerList, IEnumerable<Order> orderList)
    {
        var customerIds = orderList.Select(i => i.CustomerId).Distinct().ToHashSet();

        return customerList.Where(i => customerIds.Contains(i.Id)).ToList();
    }

    public static List<Customer> JoinListMethod(IEnumerable<Customer> customerList, IEnumerable<Order> orderList)
    {
        return customerList.Join(
                orderList,
                customer => customer.Id,
                order => order.CustomerId,
                (customer, order) => customer
            ).Distinct().ToList();
    }
}
