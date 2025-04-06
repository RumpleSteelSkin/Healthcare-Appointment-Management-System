using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;

namespace HAMS.Application.Features.Patients.Rules;

public class PatientBusinessRules(IPatientRepository patientRepository)
{
    public async Task EnsurePatientExist(string? firstName, string? lastName, DateTime birthDate,
        CancellationToken cancellationToken)
    {
        if (await patientRepository.AnyAsync(
                x => x.FirstName == firstName && x.LastName == lastName &&
                     x.BirthDate == birthDate,
                ignoreQueryFilters: true, enableTracking: false, cancellationToken: cancellationToken))
            throw new BusinessException($"Patient {firstName} {lastName} already exists.");
    }
}