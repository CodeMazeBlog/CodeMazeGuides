namespace ValueObjects.ValueObjects;

public record Result<T>
{
    public bool IsSuccess { get; private init; }
    public T? Value { get; private init; }
    public string? ErrorMessage { get; private init; }
    
    private Result(){}

    public static Result<T> Success(T value) => new() {IsSuccess = true, Value = value};
    public static Result<T> Failure(string errorMessage) => new() {IsSuccess = false, ErrorMessage = errorMessage};
}