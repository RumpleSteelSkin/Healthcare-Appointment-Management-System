using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Add;

public class HospitalAddCommandHandler(IHospitalRepository hospitalRepository, IMapper mapper)
    : IRequestHandler<HospitalAddCommand, string>
{
    public async Task<string> Handle(HospitalAddCommand request, CancellationToken cancellationToken)
    {
        if (await hospitalRepository.AnyAsync(
                x => x.Name == request.Name, ignoreQueryFilters: true, enableTracking: false,
                cancellationToken: cancellationToken))
            throw new BusinessException($"Hospital {request.Name} already exists.");
        await hospitalRepository.AddAsync(mapper.Map<Hospital>(request), cancellationToken: cancellationToken);
        return $"'{request.Name}' Hospital added.";
    }
}