namespace ExceptionHandlingInCSharp.Models;

public class GetUserResult
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }

    public static GetUserResult Success(User user)
    {
        return new GetUserResult
        {
            User = user,
            IsSuccessful = true,
        };
    }

    public static GetUserResult Error(string errorMessage)
    {
        return new GetUserResult
        {
            ErrorMessage = errorMessage
        };
    }
}
