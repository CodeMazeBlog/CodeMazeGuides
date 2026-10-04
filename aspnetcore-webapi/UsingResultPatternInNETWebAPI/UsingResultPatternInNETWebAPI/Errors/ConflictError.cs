using FluentResults;

namespace UsingResultPatternInNETWebAPI.Errors;

public class ConflictError(string message) : Error(message);
