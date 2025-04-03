namespace Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;

public class ValidationException : Exception
{
    public ValidationException()
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? message) : base(message)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
        Errors = Array.Empty<ValidationExceptionModel>();
    }

    public ValidationException(IEnumerable<ValidationExceptionModel> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    public IEnumerable<ValidationExceptionModel> Errors { get; }

    private static string BuildErrorMessage(IEnumerable<ValidationExceptionModel> errors)
    {
        IEnumerable<string> arr = errors.Select(x =>
            $"{Environment.NewLine} -- {x.Property}: {string.Join(Environment.NewLine, x.Errors ?? Array.Empty<string>())}");
        return $"Validation failed: {string.Join(string.Empty, arr)}";
    }
}