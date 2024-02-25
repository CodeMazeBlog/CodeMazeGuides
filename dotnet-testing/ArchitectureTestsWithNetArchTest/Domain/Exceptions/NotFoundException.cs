namespace Domain.Exceptions;

public abstract class NotFoundException(string message) : Exception(message)
{
}
