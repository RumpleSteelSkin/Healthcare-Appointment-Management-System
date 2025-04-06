using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Appointment.Queries.GetById;

public class AppointmentGetByIdQuery : IRequest<AppointmentGetByIdQueryResponseDto>, IRoleExists
{
    public Guid? AppointmentId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin, GeneralOperationClaims.User];
}