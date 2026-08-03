using IntroductionToCarter.Data.Exceptions.Base;

namespace IntroductionToCarter.Data.Exceptions;

public class BookNotFoundException(Guid id)
    : NotFoundException($"The book with identifier {id} was not found.")
{
}
