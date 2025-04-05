using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Patients.Queries.GetById;

public class PatientGetByIdQueryHandler(IMapper mapper, IPatientRepository patientRepository)
    : IRequestHandler<PatientGetByIdQuery, PatientGetByIdQueryResponseDto>
{
    public async Task<PatientGetByIdQueryResponseDto> Handle(PatientGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<PatientGetByIdQueryResponseDto>(await patientRepository.GetByIdAsync(
            request.PatientId ?? throw new NotFoundException("Patient not found"),
            cancellationToken: cancellationToken));
    }
}