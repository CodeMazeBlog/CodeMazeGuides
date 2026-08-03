namespace CodeMazeShop.Integration.Messages;

public class CartCheckoutMessage
{
    public Guid CartId { get; set; }

    //User Information
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

    //Order Info
    public List<LineItem> LineItems { get; set; } = new List<LineItem>();

    public int OrderTotal { get; set; }
}
