using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Delete;

public class PatientDeleteCommandHandler(IPatientRepository patientRepository)
    : IRequestHandler<PatientDeleteCommand, string>
{
    public async Task<string> Handle(PatientDeleteCommand request, CancellationToken cancellationToken)
    {
        await patientRepository.DeleteAsync(
            await patientRepository.GetByIdAsync(
                request.PatientId ?? throw new NotFoundException("Patient is not found"), include: false,
                enableTracking: false, cancellationToken: cancellationToken) ??
            throw new NotFoundException("Patient is not found"), cancellationToken: cancellationToken);
        return "Patient is deleted";
    }
}