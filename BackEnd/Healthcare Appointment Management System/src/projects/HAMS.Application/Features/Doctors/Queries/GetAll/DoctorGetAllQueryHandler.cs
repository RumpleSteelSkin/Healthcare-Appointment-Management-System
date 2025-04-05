using AutoMapper;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAll;

public class DoctorGetAllQueryHandler(IMapper mapper, IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorGetAllQuery, ICollection<DoctorGetAllQueryResponseDto>>
{
    public async Task<ICollection<DoctorGetAllQueryResponseDto>> Handle(DoctorGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<DoctorGetAllQueryResponseDto>>(
            await doctorRepository.GetAllAsync(enableTracking: false, cancellationToken: cancellationToken));
    }
}