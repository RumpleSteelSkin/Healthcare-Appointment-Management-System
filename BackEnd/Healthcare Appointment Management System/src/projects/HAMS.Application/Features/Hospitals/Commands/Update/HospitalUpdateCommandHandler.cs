using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Hospitals.Rules;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Update;

public class HospitalUpdateCommandHandler(
    IHospitalRepository hospitalRepository,
    IMapper mapper,
    HospitalBusinessRules rules)
    : IRequestHandler<HospitalUpdateCommand, string>
{
    public async Task<string> Handle(HospitalUpdateCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureHospitalExists(request.Name, cancellationToken);
        await hospitalRepository.UpdateAsync(mapper.Map(request,
            await hospitalRepository.GetByIdAsync(id: request.Id, ignoreQueryFilters: true, include: false,
                enableTracking: false, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Hospital not found")), cancellationToken: cancellationToken);
        return "Hospital is updated.";
    }
}