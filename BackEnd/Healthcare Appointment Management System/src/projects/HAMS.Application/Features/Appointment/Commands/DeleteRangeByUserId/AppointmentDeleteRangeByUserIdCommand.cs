using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.DeleteRangeByUserId;

public class AppointmentDeleteRangeByUserIdCommand : IRequest<string>
{
    public Guid userId { get; set; }
}