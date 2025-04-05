using FluentValidation;
using HAMS.Application.Constants;

namespace HAMS.Application.Features.Patients.Commands.Add;

public class PatientAddCommandValidator : AbstractValidator<PatientAddCommand>
{
    public PatientAddCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Matches(RegexPatterns.NameWithSpaces)
            .WithMessage(
                "First name can only contain letters and spaces (no numbers, symbols, or leading/trailing spaces).")
            .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Matches(RegexPatterns.NameWithSpaces)
            .WithMessage("Last name can only contain letters and spaces.")
            .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

        RuleFor(x => x.BirthDate)
            .NotEmpty().WithMessage("Birth date is required.")
            .LessThan(DateTime.Today).WithMessage("Birth date cannot be in the future.")
            .GreaterThan(DateTime.Today.AddYears(-150))
            .WithMessage("Birth date is unrealistically old (more than 150 years ago).");
    }
}