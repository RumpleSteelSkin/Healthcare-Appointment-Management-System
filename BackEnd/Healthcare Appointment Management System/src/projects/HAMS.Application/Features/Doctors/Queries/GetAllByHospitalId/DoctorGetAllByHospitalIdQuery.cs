using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAllByHospitalId;

public class DoctorGetAllByHospitalIdQuery : IRequest<ICollection<DoctorGetAllByHospitalIdQueryResponseDto>>
{
    public Guid? hospitalId { get; set; }
}