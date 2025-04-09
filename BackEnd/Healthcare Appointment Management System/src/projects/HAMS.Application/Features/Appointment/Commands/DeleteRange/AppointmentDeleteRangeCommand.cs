using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Appointment.Commands.DeleteRange;

public class AppointmentDeleteRangeCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest,ICacheRemoverRequest
{
    public ICollection<Guid>? AppointmentIds { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
    public string? CacheKey => null;

    public string? CacheGroupKey => GeneralCacheGroupKeys.Appointment;
    
}