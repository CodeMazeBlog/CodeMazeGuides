namespace CodeMazeShop.Web.Entities;

public class Product
{
    public Guid ProductId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public int Price { get; set; }
    
    public string ImageUrl { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string CategoryName { get; set; }
}