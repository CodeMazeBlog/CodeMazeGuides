namespace AggregateDesign.Domain;

public enum ErrorType
{
    NotFound,
    Conflict
}

public sealed record Error(string Code, string Description, ErrorType Type);

public class Result
{
    protected Result(Error? error) => Error = error;

    public Error? Error { get; }
    public bool IsSuccess => Error is null;

    public static Result Success() => new(null);

    public static implicit operator Result(Error error) => new(error);
}
