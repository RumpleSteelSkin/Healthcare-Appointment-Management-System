using HAMS.Application.Features.Appointment.Commands.DeleteRange;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.DeleteRangeByUserId;

public class AppointmentDeleteRangeByUserIdCommandHandler(IAppointmentRepository appointmentRepository, IMediator mediator)
    : IRequestHandler<AppointmentDeleteRangeByUserIdCommand, string>
{
    public async Task<string> Handle(AppointmentDeleteRangeByUserIdCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new AppointmentDeleteRangeCommand()
        {
            AppointmentIds = (await appointmentRepository.GetAllAsync(filter: x => x.PatientId == request.userId,
                    ignoreQueryFilters: true,enableTracking:false, include: false, cancellationToken: cancellationToken))
                .Select(item => item.Id)
                .ToList()
        }, cancellationToken);
        return $"UserId {request.userId} appointments deleted.";
    }
}