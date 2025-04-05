using FluentValidation;

namespace HAMS.Application.Features.Hospitals.Commands.Update;

public class HospitalUpdateCommandValidator : AbstractValidator<HospitalUpdateCommand>
{
    public HospitalUpdateCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Hospital name is required.")
            .MaximumLength(250).WithMessage("Hospital name must not exceed 250 characters.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(500).WithMessage("Address must not exceed 500 characters.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100).WithMessage("City name must not exceed 100 characters.");
    }
}