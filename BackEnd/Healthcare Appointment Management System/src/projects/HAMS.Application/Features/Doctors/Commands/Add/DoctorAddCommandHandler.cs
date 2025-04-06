using AutoMapper;
using HAMS.Application.Features.Doctors.Rules;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Add;

public class DoctorAddCommandHandler(IMapper mapper, IDoctorRepository doctorRepository, DoctorBusinessRules rules)
    : IRequestHandler<DoctorAddCommand, string>
{
    public async Task<string> Handle(DoctorAddCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureDoctorIsUnique(request.FirstName, request.LastName, request.Specialty, cancellationToken);
        await rules.EnsureDoctorSpecialtyLimit(request.HospitalId, request.Specialty, cancellationToken);
        await doctorRepository.AddAsync(mapper.Map<Doctor>(request), cancellationToken: cancellationToken);
        return $"Doctor {request.FirstName} {request.LastName} has been successfully added.";
    }
}