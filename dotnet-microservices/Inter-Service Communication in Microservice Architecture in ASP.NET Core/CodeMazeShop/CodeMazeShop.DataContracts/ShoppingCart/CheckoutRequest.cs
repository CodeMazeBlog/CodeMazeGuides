namespace CodeMazeShop.DataContracts.ShoppingCart;

public class CheckoutRequest
{
    public Guid CartId { get; set; }

    public Guid UserId { get; set; }   

    public string FirstName { get; set; }

    public string LastName { get; set; }
        
    public string Email { get; set; }

    public string Address { get; set; }
        
    public string ZipCode { get; set; }
        
    public string City { get; set; }
        
    public string Country { get; set; }

    //payment information
    public string CardNumber { get; set; }
    
    public string CardName { get; set; }
    
    public string CardExpiration { get; set; }
        
    public string CvvCode { get; set; }
}