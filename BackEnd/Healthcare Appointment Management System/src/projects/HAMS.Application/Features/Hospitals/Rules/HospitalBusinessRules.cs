using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;

namespace HAMS.Application.Features.Hospitals.Rules;

public class HospitalBusinessRules(IHospitalRepository hospitalRepository)
{
    public async Task EnsureHospitalExists(string? name, CancellationToken cancellationToken)
    {
        if (await hospitalRepository.AnyAsync(
                x => x.Name == name, ignoreQueryFilters: true, enableTracking: false,
                cancellationToken: cancellationToken))
            throw new BusinessException($"Hospital {name} already exists.");
    }
}