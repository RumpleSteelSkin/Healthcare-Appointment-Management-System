using FluentValidation;

namespace HAMS.Application.Features.Appointment.Commands.Add;

public class AppointmentAddCommandValidator : AbstractValidator<AppointmentAddCommand>
{
    public AppointmentAddCommandValidator()
    {
        RuleFor(x => x.AppointmentDate)
            .NotEmpty().WithMessage("Appointment date is required.")
            .GreaterThan(DateTime.Now).WithMessage("Appointment date must be in the future.")
            .LessThan(DateTime.Now.AddYears(5)).WithMessage("Appointment date is too far in the future.");

        RuleFor(x => x.DoctorId)
            .NotNull().WithMessage("Doctor ID is required.");

        RuleFor(x => x.PatientId)
            .NotNull().WithMessage("Patient ID is required.");

        RuleFor(x => x.Notes)
            .MaximumLength(10000).WithMessage("Notes must not exceed 10000 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Notes));
    }
}