using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Update;

public class DoctorUpdateCommandHandler(IMapper mapper, IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorUpdateCommand, string>
{
    public async Task<string> Handle(DoctorUpdateCommand request, CancellationToken cancellationToken)
    {
        if (await doctorRepository.AnyAsync(
                x => x.FirstName == request.FirstName && x.LastName == request.LastName &&
                     x.Specialty == request.Specialty,
                ignoreQueryFilters: true, enableTracking: false, cancellationToken: cancellationToken))
            throw new BusinessException($"Doctor {request.FirstName} {request.LastName} already exists.");
        await doctorRepository.UpdateAsync(
            mapper.Map(request,
                await doctorRepository.GetByIdAsync(id: request.Id, enableTracking: false, include: false,
                    cancellationToken: cancellationToken) ?? throw new NotFoundException("Doctor not found")),
            cancellationToken: cancellationToken);
        return "Doctor is updated";
    }
}