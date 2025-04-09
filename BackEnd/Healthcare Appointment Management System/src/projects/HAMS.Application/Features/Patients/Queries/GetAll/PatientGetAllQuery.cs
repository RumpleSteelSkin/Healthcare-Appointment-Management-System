using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Queries.GetAll;

public class PatientGetAllQuery : IRequest<ICollection<PatientGetAllQueryResponseDto>>, IRoleExists, ICacheAbleRequest
{
    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => "PatientGetAllQuery";

    public string? CacheGroupKey => GeneralCacheGroupKeys.Patient;

    public TimeSpan? SlidingExpiration => null;
}