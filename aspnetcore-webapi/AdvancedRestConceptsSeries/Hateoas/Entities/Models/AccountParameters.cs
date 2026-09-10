namespace Entities.Models;

public class AccountParameters : QueryStringParameters
{
    public AccountParameters()
    {
        OrderBy = "DateCreated";
    }
}
