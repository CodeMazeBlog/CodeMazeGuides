namespace UsingResultPatternInNETWebAPI.v3.Exceptions;

public class ApiNotFoundException : Exception
{
    public ApiNotFoundException(Guid id)
        : base($"contact with id {id} was not found")
    {
    }
}