using AutomaticRegistrationOfMinimalAPIs.Data.Exceptions.Base;

namespace AutomaticRegistrationOfMinimalAPIs.Data.Exceptions;

public class TeacherNotFoundException(Guid id)
: NotFoundException($"The teacher with the identifier {id} was not found.")
{
}
