using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;

namespace HAMS.Application.Features.Doctors.Rules;

public class DoctorBusinessRules(IDoctorRepository doctorRepository)
{
    public async Task EnsureDoctorIsUnique(string? firstName, string? lastName, string? speciality,
        CancellationToken cancellationToken)
    {
        if (await doctorRepository.AnyAsync(
                x => x.FirstName == firstName && x.LastName == lastName &&
                     x.Specialty == speciality,
                ignoreQueryFilters: true, enableTracking: false, cancellationToken: cancellationToken))
            throw new BusinessException($"Doctor {firstName} {lastName} already exists.");
    }

    public async Task EnsureDoctorSpecialtyLimit(Guid? hospitalId, string? specialty,
        CancellationToken cancellationToken)
    {
        if (await doctorRepository.CountAsync(
                x => x.HospitalId == hospitalId && x.Specialty == specialty,
                cancellationToken: cancellationToken) >= 10)
            throw new BusinessException($"The hospital already has 10 doctors with the '{specialty}' specialty.");
    }
    
    public async Task EnsureDoctorSpecialtyLimitForUpdate(Guid doctorId, Guid? hospitalId, string? specialty, CancellationToken cancellationToken)
    {
        if (await doctorRepository.CountAsync(
                x => x.HospitalId == hospitalId && x.Specialty == specialty && x.Id != doctorId,
                cancellationToken: cancellationToken) >= 10)
            throw new BusinessException($"The hospital already has 10 doctors with the '{specialty}' specialty.");
    }

}