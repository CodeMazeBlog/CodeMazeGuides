namespace UsingResultPatternInNETWebAPI.Exceptions;

public class RecordNotFoundException(string message) : Exception(message);
