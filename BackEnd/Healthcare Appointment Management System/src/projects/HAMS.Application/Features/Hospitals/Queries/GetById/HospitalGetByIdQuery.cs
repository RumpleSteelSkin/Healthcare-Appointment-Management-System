using MediatR;

namespace HAMS.Application.Features.Hospitals.Queries.GetById;

public class HospitalGetByIdQuery : IRequest<HospitalGetByIdQueryResponseDto>
{
    public Guid? HospitalId { get; set; }
}