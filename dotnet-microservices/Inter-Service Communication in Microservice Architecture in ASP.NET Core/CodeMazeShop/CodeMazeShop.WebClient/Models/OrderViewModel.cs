using CodeMazeShop.DataContracts.Ordering;

namespace CodeMazeShop.WebClient.Models;

public class OrderViewModel
{
    public IEnumerable<Order> Orders { get; set; }
}
