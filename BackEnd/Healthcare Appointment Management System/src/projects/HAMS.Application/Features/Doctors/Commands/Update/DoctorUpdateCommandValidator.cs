using FluentValidation;
using HAMS.Application.Constants;

namespace HAMS.Application.Features.Doctors.Commands.Update;

public class DoctorUpdateCommandValidator : AbstractValidator<DoctorUpdateCommand>
{
    public DoctorUpdateCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Doctor ID is required.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Matches(RegexPatterns.NameWithSpaces)
            .WithMessage(
                "First name can only contain letters and spaces (no numbers, symbols, or leading/trailing spaces).")
            .MaximumLength(100).WithMessage("First name must not exceed 100 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Matches(RegexPatterns.NameWithSpaces)
            .WithMessage(
                "First name can only contain letters and spaces (no numbers, symbols, or leading/trailing spaces).")
            .MaximumLength(100).WithMessage("Last name must not exceed 100 characters.");

        RuleFor(x => x.Specialty)
            .MaximumLength(150).WithMessage("Specialty must not exceed 150 characters.");

        RuleFor(x => x.HospitalId)
            .NotEmpty().WithMessage("Hospital ID is required.");
    }
}