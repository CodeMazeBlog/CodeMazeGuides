namespace UsingResultPatternInNETWebAPI.TheResultPattern;

public class CustomResult<T>
{
    private readonly T? _value;

    private CustomResult(T value)
    {
        Value = value;
        IsSuccess = true;
        Error = CustomError.None;
    }

    private CustomResult(bool isSuccess, CustomError error)
    {
        if ((isSuccess && error != CustomError.None) ||
            (!isSuccess && error == CustomError.None))
        {
            throw new ArgumentException("invalid error", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public T Value
    {
        get
        {
            if (IsFailure)
            {
                throw new InvalidOperationException("there is no value for failure");
            }

            return _value!;
        }

        private init => _value = value;
    }

    public CustomError Error { get; }

    public static CustomResult<T> Success(T value)
    {
        return new CustomResult<T>(value);
    }

    public static CustomResult<T> Failure(CustomError error)
    {
        return new CustomResult<T>(false, error);
    }
}