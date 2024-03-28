using AutomaticRegistrationOfMinimalAPIs.Data.Exceptions.Base;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Exceptions;

public class StudentNotFoundException(Guid id)
    : NotFoundException($"The student with the identifier {id} was not found.")
{
}
