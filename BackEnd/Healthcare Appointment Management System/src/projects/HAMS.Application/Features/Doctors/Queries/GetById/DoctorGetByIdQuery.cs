using HAMS.Application.Features.Doctors.Queries.GetAll;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetById;

public class DoctorGetByIdQuery : IRequest<DoctorGetAllQueryResponseDto>
{
    public Guid? DoctorId { get; set; }
}