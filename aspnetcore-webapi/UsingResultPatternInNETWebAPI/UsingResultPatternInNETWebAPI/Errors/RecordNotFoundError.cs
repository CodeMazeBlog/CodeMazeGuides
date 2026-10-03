using FluentResults;

namespace UsingResultPatternInNETWebAPI.Errors;

public class RecordNotFoundError(string message) : Error(message);
