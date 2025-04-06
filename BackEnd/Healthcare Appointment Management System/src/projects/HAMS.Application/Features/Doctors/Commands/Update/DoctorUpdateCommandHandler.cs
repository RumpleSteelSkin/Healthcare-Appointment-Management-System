using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Doctors.Rules;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Update;

public class DoctorUpdateCommandHandler(IMapper mapper, IDoctorRepository doctorRepository, DoctorBusinessRules rules)
    : IRequestHandler<DoctorUpdateCommand, string>
{
    public async Task<string> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
    {
        await rules.EnsureDoctorSpecialtyLimitForUpdate(request.Id, request.HospitalId, request.Specialty, cancellationToken);
        await doctorRepository.UpdateAsync(
            mapper.Map(request,
                await doctorRepository.GetByIdAsync(id: request.Id, include: false,
                    cancellationToken: cancellationToken) ?? throw new NotFoundException("Doctor not found")),
            cancellationToken: cancellationToken);
        return "Doctor is updated";
    }
}