using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Appointment.Rules;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Update;

public class AppointmentUpdateCommandHandler(
    IAppointmentRepository appointmentRepository,
    AppointmentBusinessRules rules,
    IMapper mapper) : IRequestHandler<AppointmentUpdateCommand, string>
{
    public async Task<string> Handle(AppointmentUpdateCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureAppointmentExists(request.Id, cancellationToken);
        await rules.EnsureDoctorExists(request.DoctorId, cancellationToken);
        await rules.EnsurePatientExists(request.PatientId, cancellationToken);
        await rules.EnsureAppointmentDateIsUnique(request.Id, request.AppointmentDate, request.Notes,
            cancellationToken);
        await appointmentRepository.UpdateAsync(mapper.Map(request, await appointmentRepository.GetByIdAsync(request.Id,
                ignoreQueryFilters: true, enableTracking: true, include: false,
                cancellationToken: cancellationToken) ?? throw new BusinessException("Appointment not updated.")),
            cancellationToken: cancellationToken);
        return "Appointment is updated.";
    }
}