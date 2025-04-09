using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Update;

public class PatientUpdateCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest,
    ICacheRemoverRequest
{
    public Guid? Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => null;

    public string? CacheGroupKey => GeneralCacheGroupKeys.Patient;
}