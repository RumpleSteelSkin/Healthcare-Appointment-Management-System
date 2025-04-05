﻿using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Update;

public class PatientUpdateCommandHandler(IMapper mapper, IPatientRepository patientRepository):IRequestHandler<PatientUpdateCommand,string>
{
    public async Task<string> Handle(PatientUpdateCommand request, CancellationToken cancellationToken)
    {
        await patientRepository.UpdateAsync(
            mapper.Map(request,
                await patientRepository.GetByIdAsync(id: request.Id ?? throw new NotFoundException("Patient not found"),
                    enableTracking: false, include: false, cancellationToken: cancellationToken) ??
                throw new NotFoundException("Patient not found")), cancellationToken: cancellationToken);
        return "Patient is updated.";
    }
}