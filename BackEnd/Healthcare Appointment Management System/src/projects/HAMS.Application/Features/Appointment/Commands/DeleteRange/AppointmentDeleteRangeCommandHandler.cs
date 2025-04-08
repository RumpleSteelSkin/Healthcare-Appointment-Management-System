using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.DeleteRange;

public class AppointmentDeleteRangeCommandHandler(IAppointmentRepository appointmentRepository)
    : IRequestHandler<AppointmentDeleteRangeCommand, string>
{
    public async Task<string> Handle(AppointmentDeleteRangeCommand request, CancellationToken cancellationToken)
    {
        await appointmentRepository.DeleteRangeAsync((await appointmentRepository.GetByIdsAsync(request.AppointmentIds,
               ignoreQueryFilters:true, enableTracking: false, include: false,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Appointments not found"))!,
            cancellationToken);
        return "Appointment Deleted";
    }
}