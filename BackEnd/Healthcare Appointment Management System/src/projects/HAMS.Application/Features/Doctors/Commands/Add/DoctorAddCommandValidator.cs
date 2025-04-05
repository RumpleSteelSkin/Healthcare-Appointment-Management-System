using FluentValidation;
using HAMS.Application.Constants;

namespace HAMS.Application.Features.Doctors.Commands.Add;

public class DoctorAddCommandValidator : AbstractValidator<DoctorAddCommand>
{
    public DoctorAddCommandValidator()
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

        RuleFor(x => x.Specialty)
            .MaximumLength(150)
            .WithMessage("Specialty must not exceed 150 characters.");

        RuleFor(x => x.HospitalId)
            .NotNull().WithMessage("Hospital ID is required.")
            .NotEqual(Guid.Empty).WithMessage("Hospital ID must be a valid GUID.");
    }
}