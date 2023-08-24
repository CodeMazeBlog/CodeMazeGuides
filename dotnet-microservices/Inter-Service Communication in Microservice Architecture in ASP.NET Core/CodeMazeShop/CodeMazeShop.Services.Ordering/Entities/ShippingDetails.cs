namespace CodeMazeShop.Services.Ordering.Entities;

public class ShippingDetails
{
    public string ShippingDetailsId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Address { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    //Navigation Properties
    public string OrderId { get; set; }

    public Order Order { get; set; }
}
