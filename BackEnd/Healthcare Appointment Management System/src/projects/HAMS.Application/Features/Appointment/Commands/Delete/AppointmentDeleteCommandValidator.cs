using FluentValidation;

namespace HAMS.Application.Features.Appointment.Commands.Delete;

public class AppointmentDeleteCommandValidator : AbstractValidator<AppointmentDeleteCommand>
{
    public AppointmentDeleteCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Appointment ID is required.");
    }
}