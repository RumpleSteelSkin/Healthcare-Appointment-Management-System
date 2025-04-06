using AutoMapper;
using HAMS.Application.Features.Appointment.Rules;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Add;

public class AppointmentAddCommandHandler(
    IAppointmentRepository appointmentRepository,
    AppointmentBusinessRules rules,
    IMapper mapper)
    : IRequestHandler<AppointmentAddCommand, string>
{
    public async Task<string> Handle(AppointmentAddCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureDoctorExists(request.DoctorId, cancellationToken);
        await rules.EnsurePatientExists(request.PatientId, cancellationToken);
        await rules.EnsureNoDuplicateAppointment(request.DoctorId, request.PatientId, request.AppointmentDate,
            cancellationToken);
        await appointmentRepository.AddAsync(mapper.Map<Domain.Models.Appointment>(request),
            cancellationToken: cancellationToken);
        return "Appointment is added";
    }
}