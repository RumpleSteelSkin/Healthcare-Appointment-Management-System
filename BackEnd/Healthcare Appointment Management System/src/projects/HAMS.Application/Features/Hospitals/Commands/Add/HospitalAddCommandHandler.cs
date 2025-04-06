using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Hospitals.Rules;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Add;

public class HospitalAddCommandHandler(
    IHospitalRepository hospitalRepository,
    IMapper mapper,
    HospitalBusinessRules rules)
    : IRequestHandler<HospitalAddCommand, string>
{
    public async Task<string> Handle(HospitalAddCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureHospitalExists(request.Name, cancellationToken);
        await hospitalRepository.AddAsync(mapper.Map<Hospital>(request), cancellationToken: cancellationToken);
        return $"'{request.Name}' Hospital added.";
    }
}