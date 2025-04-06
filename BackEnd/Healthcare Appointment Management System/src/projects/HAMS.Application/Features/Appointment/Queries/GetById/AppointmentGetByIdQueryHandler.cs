using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Queries.GetById;

public class AppointmentGetByIdQueryHandler(IAppointmentRepository appointmentRepository, IMapper mapper)
    : IRequestHandler<AppointmentGetByIdQuery, AppointmentGetByIdQueryResponseDto>
{
    public async Task<AppointmentGetByIdQueryResponseDto> Handle(AppointmentGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<AppointmentGetByIdQueryResponseDto>(await appointmentRepository.GetByIdAsync(
            id: request.AppointmentId ?? throw new NotFoundException("Appoitnment not found"), enableTracking: false,
            cancellationToken: cancellationToken));
    }
}