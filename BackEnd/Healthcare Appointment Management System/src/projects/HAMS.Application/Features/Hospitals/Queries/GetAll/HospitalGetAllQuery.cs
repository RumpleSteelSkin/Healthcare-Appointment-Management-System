using MediatR;

namespace HAMS.Application.Features.Hospitals.Queries.GetAll;

public class HospitalGetAllQuery : IRequest<ICollection<HospitalGetAllQueryResponseDto>>;