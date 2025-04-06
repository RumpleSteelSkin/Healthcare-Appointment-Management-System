using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.Repositories;

namespace HAMS.Application.Features.Appointment.Rules;

public class AppointmentBusinessRules(
    IAppointmentRepository appointmentRepository,
    IDoctorRepository doctorRepository,
    IPatientRepository patientRepository)
{
    public async Task EnsureAppointmentExists(Guid? appointmentId, CancellationToken cancellationToken)
    {
        if (await appointmentRepository.GetByIdAsync(
                appointmentId ?? throw new NotFoundException("Appointment not found"),
                ignoreQueryFilters: true, enableTracking: true, include: false,
                cancellationToken: cancellationToken) is null)
            throw new NotFoundException("Appointment not found.");
    }

    public async Task EnsureDoctorExists(Guid? doctorId, CancellationToken cancellationToken)
    {
        if (await doctorRepository.GetByIdAsync(doctorId ?? throw new NotFoundException("Doctor not found"),
                ignoreQueryFilters: true, enableTracking: false, include: false,
                cancellationToken: cancellationToken) is null)
            throw new NotFoundException("Doctor not found.");
    }

    public async Task EnsurePatientExists(Guid? patientId, CancellationToken cancellationToken)
    {
        if (await patientRepository.GetByIdAsync(patientId ?? throw new NotFoundException("Patient not found"),
                ignoreQueryFilters: true, enableTracking: false, include: false,
                cancellationToken: cancellationToken) is null)
            throw new NotFoundException("Patient not found.");
    }

    public async Task EnsureAppointmentDateIsUnique(Guid currentId, DateTime date, string? notes,
        CancellationToken cancellationToken)
    {
        if (await appointmentRepository.AnyAsync(
                x => x.Id != currentId && x.AppointmentDate == date && x.Notes == notes,
                cancellationToken: cancellationToken))
            throw new BusinessException("Another appointment with the same date and notes already exists.");
    }

    public async Task EnsureNoDuplicateAppointment(Guid? doctorId, Guid? patientId, DateTime appointmentDate,
        CancellationToken cancellationToken)
    {
        if (await appointmentRepository.AnyAsync(
                x => x.AppointmentDate == appointmentDate &&
                     x.DoctorId == doctorId &&
                     x.PatientId == patientId,
                cancellationToken: cancellationToken))
            throw new BusinessException(
                "An appointment for this doctor and patient at the specified time already exists.");
    }

    public async Task EnsurePatientAppointmentFrequency(Guid doctorId, Guid patientId, DateTime appointmentDate,
        CancellationToken cancellationToken)
    {
        if (await appointmentRepository.AnyAsync(
                x => x.DoctorId == doctorId && x.PatientId == patientId &&
                     x.AppointmentDate >= appointmentDate.AddDays(-7) &&
                     x.AppointmentDate <= appointmentDate.AddDays(7), cancellationToken: cancellationToken))
            throw new BusinessException(
                "A patient can only have one appointment with the same doctor within one week.");
    }
}