namespace EventTicketing.Domain;

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

public sealed class Result<TValue> : Result
{
    private readonly TValue? _value;

    private Result(TValue? value, Error? error)
        : base(error) => _value = value;

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("A failed result has no value.");

    public static implicit operator Result<TValue>(TValue value) =>
        new(value, null);

    public static implicit operator Result<TValue>(Error error) =>
        new(default, error);
}
