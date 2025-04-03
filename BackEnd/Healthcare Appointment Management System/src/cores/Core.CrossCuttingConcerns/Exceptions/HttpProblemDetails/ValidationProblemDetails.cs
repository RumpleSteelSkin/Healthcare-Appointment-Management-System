using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public ValidationProblemDetails(IEnumerable<ValidationExceptionModel> errors)
    {
        Title = "Validation error(s)";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/problems/validation";
    }

    public IEnumerable<ValidationExceptionModel> Errors { get; set; }
}