using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Appointment.Queries.GetAll;

public class AppointmentGetAllQuery : IRequest<ICollection<AppointmentGetAllQueryResponseDto>>, IRoleExists,
    ITransactional, ILoggableRequest
{
    public string[] Roles => [GeneralOperationClaims.Admin];
}