using CodeMazeShop.Web.Entities;

namespace CodeMazeShop.Web.Models;

public class OrderViewModel
{
    public IEnumerable<Order> Orders { get; set; }
}
