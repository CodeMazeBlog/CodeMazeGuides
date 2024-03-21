namespace UsingResultPatternInNETWebAPI.v5.Errors;

public class ApiNotFoundError : Error
{
    public ApiNotFoundError(Guid id)
        : base($"contact with id {id} was not found")
    {
    }
}