using Core.Application.Pipelines.Caching;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAllByHospitalId;

public class DoctorGetAllByHospitalIdQuery : IRequest<ICollection<DoctorGetAllByHospitalIdQueryResponseDto>>,ICacheAbleRequest
{
    public Guid? hospitalId { get; set; }
    public string? CacheKey => $"DoctorGetAllByHospitalIdQuery{hospitalId}";

    public string? CacheGroupKey => GeneralCacheGroupKeys.Doctor;

    public TimeSpan? SlidingExpiration => null;
}