using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Delete;

public class DoctorDeleteCommandHandler(IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorDeleteCommand, string>
{
    public async Task<string> Handle(DoctorDeleteCommand request, CancellationToken cancellationToken)
    {
        await doctorRepository.DeleteAsync(
            await doctorRepository.GetByIdAsync(request.DoctorId, enableTracking: false, include: false,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Doctor not found"),
            cancellationToken: cancellationToken);
        return "Doctor is deleted";
    }
}