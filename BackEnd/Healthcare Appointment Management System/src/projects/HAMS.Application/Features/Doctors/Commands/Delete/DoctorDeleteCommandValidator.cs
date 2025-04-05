using FluentValidation;

namespace HAMS.Application.Features.Doctors.Commands.Delete;

public class DoctorDeleteCommandValidator : AbstractValidator<DoctorDeleteCommand>
{
    public DoctorDeleteCommandValidator()
    {
        RuleFor(x => x.DoctorId)
            .NotEmpty().WithMessage("Doctor ID is required.");
    }
}