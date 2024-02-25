namespace Domain.Exceptions;

public sealed class CatNotFoundException(Guid id)
    : NotFoundException($"The cat with the identifier {id} was not found.")
{
}
