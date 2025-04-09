using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.Delete;

public class AppointmentDeleteCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest,ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin,GeneralOperationClaims.User];
    public string? CacheKey => null;

    public string? CacheGroupKey => GeneralCacheGroupKeys.Appointment;
}