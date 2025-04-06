using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Update;

public class AppointmentUpdateCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public Guid Id { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string? Notes { get; set; }
    public Guid? DoctorId { get; set; }
    public Guid? PatientId { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin, GeneralOperationClaims.User];
}