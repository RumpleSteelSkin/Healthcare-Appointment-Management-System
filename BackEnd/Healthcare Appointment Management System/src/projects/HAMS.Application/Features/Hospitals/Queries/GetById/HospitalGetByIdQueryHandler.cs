using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Queries.GetById;

public class HospitalGetByIdQueryHandler(IMapper mapper, IHospitalRepository hospitalRepository)
    : IRequestHandler<HospitalGetByIdQuery, HospitalGetByIdQueryResponseDto>
{
    public async Task<HospitalGetByIdQueryResponseDto> Handle(HospitalGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<HospitalGetByIdQueryResponseDto>(await hospitalRepository.GetByIdAsync(
            id: request.HospitalId ?? throw new NotFoundException("Hospital not found."),
            ignoreQueryFilters: true, enableTracking: false, include: false, cancellationToken: cancellationToken));
    }
}