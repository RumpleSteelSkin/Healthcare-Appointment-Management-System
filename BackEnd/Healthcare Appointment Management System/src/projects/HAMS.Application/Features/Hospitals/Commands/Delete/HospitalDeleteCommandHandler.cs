using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Delete;

public class HospitalDeleteCommandHandler(IHospitalRepository hospitalRepository)
    : IRequestHandler<HospitalDeleteCommand, string>
{
    public async Task<string> Handle(HospitalDeleteCommand request, CancellationToken cancellationToken)
    {
        await hospitalRepository.DeleteAsync(
            await hospitalRepository.GetByIdAsync(request.Id, enableTracking: false, include: false,
                cancellationToken: cancellationToken) ?? throw new NotFoundException("Hospital not found"),
            cancellationToken: cancellationToken);
        return "Hospital is deleted.";
    }
}