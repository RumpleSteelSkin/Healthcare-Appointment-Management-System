using Core.Application.Pipelines.Caching;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAll;

public class DoctorGetAllQuery : IRequest<ICollection<DoctorGetAllQueryResponseDto>>,ICacheAbleRequest
{
    public string? CacheKey => "DoctorGetAllQuery";

    public string? CacheGroupKey => GeneralCacheGroupKeys.Doctor;

    public TimeSpan? SlidingExpiration => null;
}