using AutoMapper;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Queries.GetAll;

public class
    HospitalGetAllQueryHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    : IRequestHandler<HospitalGetAllQuery, ICollection<HospitalGetAllQueryResponseDto>>
{
    public async Task<ICollection<HospitalGetAllQueryResponseDto>> Handle(HospitalGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<HospitalGetAllQueryResponseDto>>(
            await hospitalRepository.GetAllAsync(enableTracking: false, include: false,
                cancellationToken: cancellationToken));
    }
}