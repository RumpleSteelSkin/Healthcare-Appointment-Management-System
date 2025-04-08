using AutoMapper;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetAllByHospitalId;

public class DoctorGetAllByHospitalIdQueryHandler(IMapper mapper, IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorGetAllByHospitalIdQuery, ICollection<DoctorGetAllByHospitalIdQueryResponseDto>>
{
    public async Task<ICollection<DoctorGetAllByHospitalIdQueryResponseDto>> Handle(
        DoctorGetAllByHospitalIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<DoctorGetAllByHospitalIdQueryResponseDto>>(
            await doctorRepository.GetAllAsync(filter: x => x.HospitalId == request.hospitalId, enableTracking: false,
                cancellationToken: cancellationToken));
    }
}