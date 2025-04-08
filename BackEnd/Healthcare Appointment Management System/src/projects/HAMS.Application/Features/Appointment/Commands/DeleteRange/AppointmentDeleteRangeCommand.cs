using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.DeleteRange;

public class AppointmentDeleteRangeCommand : IRequest<string>
{
    public ICollection<Guid>? AppointmentIds { get; set; }
}