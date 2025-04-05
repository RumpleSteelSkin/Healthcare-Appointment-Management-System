using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using FluentValidation;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Add;

public class AppointmentAddCommand : IRequest<string>
{
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
}

public class AppointmentAddCommandHandler(
    IAppointmentRepository appointmentRepository,
    IDoctorRepository doctorRepository,
    IPatientRepository patientRepository,
    IMapper mapper)
    : IRequestHandler<AppointmentAddCommand, string>
{
    public async Task<string> Handle(AppointmentAddCommand request, CancellationToken cancellationToken)
    {
        if (await doctorRepository.GetByIdAsync(request.DoctorId ?? throw new NotFoundException("Doctor not found"),
                ignoreQueryFilters: true, enableTracking: false, include: false,
                cancellationToken: cancellationToken) is null)
            throw new NotFoundException("Doctor not found");
        if (await patientRepository.GetByIdAsync(request.PatientId ?? throw new NotFoundException("Patient not found"),
                ignoreQueryFilters: true, enableTracking: false, include: false,
                cancellationToken: cancellationToken) is null)
            throw new NotFoundException("Patient not found");
        if (await appointmentRepository.AnyAsync(
                x => x.AppointmentDate == request.AppointmentDate && x.Notes == request.Notes,
                cancellationToken: cancellationToken))
            throw new BusinessException("Appointment is exist");
        
        //TODO: BURDAN DEVAM...
        
        
        

        return "Appointment is added";
    }
}

public class AppointmentAddCommandValidator : AbstractValidator<AppointmentAddCommand>
{
}