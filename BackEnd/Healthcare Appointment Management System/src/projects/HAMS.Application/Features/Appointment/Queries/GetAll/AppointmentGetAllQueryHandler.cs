using AutoMapper;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Queries.GetAll;

public class AppointmentGetAllQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    : IRequestHandler<AppointmentGetAllQuery, ICollection<AppointmentGetAllQueryResponseDto>>
{
    public async Task<ICollection<AppointmentGetAllQueryResponseDto>> Handle(AppointmentGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<AppointmentGetAllQueryResponseDto>>(
            await appointmentRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken));
    }
}