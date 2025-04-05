using AutoMapper;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Patients.Queries.GetAll;

public class PatientGetAllQueryHandler(IMapper mapper, IPatientRepository patientRepository)
    : IRequestHandler<PatientGetAllQuery, ICollection<PatientGetAllQueryResponseDto>>
{
    public async Task<ICollection<PatientGetAllQueryResponseDto>> Handle(PatientGetAllQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<PatientGetAllQueryResponseDto>>(
            await patientRepository.GetAllAsync(include: false, enableTracking: false,
                cancellationToken: cancellationToken));
    }
}