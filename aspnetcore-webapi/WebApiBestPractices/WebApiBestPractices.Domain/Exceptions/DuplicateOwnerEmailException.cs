namespace WebApiBestPractices.Domain.Exceptions;

public class DuplicateOwnerEmailException(string email)
    : Exception($"An owner with the email '{email}' already exists.");
