using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAll;

public class DoctorGetAllQuery : IRequest<ICollection<DoctorGetAllQueryResponseDto>>;