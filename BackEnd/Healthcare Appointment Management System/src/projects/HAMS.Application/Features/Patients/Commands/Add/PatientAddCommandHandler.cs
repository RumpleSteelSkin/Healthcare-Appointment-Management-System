using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Patients.Rules;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Add;

public class PatientAddCommandHandler(IMapper mapper, IPatientRepository patientRepository, PatientBusinessRules rules)
    : IRequestHandler<PatientAddCommand, string>
{
    public async Task<string> Handle(PatientAddCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsurePatientExist(request.FirstName, request.LastName, request.BirthDate, cancellationToken);
        await patientRepository.AddAsync(mapper.Map<Patient>(request), cancellationToken: cancellationToken);
        return "Patient is added";
    }
}