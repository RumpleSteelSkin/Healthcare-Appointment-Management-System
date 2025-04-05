using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Add;

public class PatientAddCommandHandler(IMapper mapper, IPatientRepository patientRepository)
    : IRequestHandler<PatientAddCommand, string>
{
    public async Task<string> Handle(PatientAddCommand request, CancellationToken cancellationToken)
    {
        if (await patientRepository.AnyAsync(
                x => x.FirstName == request.FirstName && x.LastName == request.LastName &&
                     x.BirthDate == request.BirthDate,
                ignoreQueryFilters: true, enableTracking: false, cancellationToken: cancellationToken))
            throw new BusinessException($"Patient {request.FirstName} {request.LastName} already exists.");
        await patientRepository.AddAsync(mapper.Map<Patient>(request), cancellationToken: cancellationToken);
        return "Patient is added";
    }
}