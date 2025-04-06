using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Delete;

public class AppointmentDeleteCommandHandler(IAppointmentRepository appointmentRepository)
    : IRequestHandler<AppointmentDeleteCommand, string>
{
    public async Task<string> Handle(AppointmentDeleteCommand request, CancellationToken cancellationToken)
    {
        await appointmentRepository.DeleteAsync(
            await appointmentRepository.GetByIdAsync(request.Id, enableTracking: false, include: false,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Appointment is not found"),
            cancellationToken: cancellationToken);
        return "Appointment is deleted.";
    }
}