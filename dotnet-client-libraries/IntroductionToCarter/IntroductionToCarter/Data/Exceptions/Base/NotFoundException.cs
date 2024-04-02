namespace IntroductionToCarter.Data.Exceptions.Base;

public abstract class NotFoundException(string message)
    : Exception(message)
{
}
