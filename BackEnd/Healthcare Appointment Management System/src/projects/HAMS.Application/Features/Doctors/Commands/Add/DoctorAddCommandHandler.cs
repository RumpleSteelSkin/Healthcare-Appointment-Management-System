using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Add;

public class DoctorAddCommandHandler(IMapper mapper, IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorAddCommand, string>
{
    public async Task<string> Handle(DoctorAddCommand request, CancellationToken cancellationToken)
    {
        if (await doctorRepository.AnyAsync(
                x => x.FirstName == request.FirstName && x.LastName == request.LastName &&
                     x.Specialty == request.Specialty,
                ignoreQueryFilters: true, enableTracking: false, cancellationToken: cancellationToken))
            throw new BusinessException($"Doctor {request.FirstName} {request.LastName} already exists.");
        await doctorRepository.AddAsync(mapper.Map<Doctor>(request), cancellationToken: cancellationToken);
        return $"Doctor {request.FirstName} {request.LastName} has been successfully added.";
    }
}