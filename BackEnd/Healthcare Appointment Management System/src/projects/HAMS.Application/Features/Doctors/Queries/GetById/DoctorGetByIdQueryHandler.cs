using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Doctors.Queries.GetAll;
using HAMS.Application.Services.Repositories;
using MediatR;

namespace HAMS.Application.Features.Doctors.Queries.GetById;

public class DoctorGetByIdQueryHandler(IMapper mapper, IDoctorRepository doctorRepository)
    : IRequestHandler<DoctorGetByIdQuery, DoctorGetAllQueryResponseDto>
{
    public async Task<DoctorGetAllQueryResponseDto> Handle(DoctorGetByIdQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<DoctorGetAllQueryResponseDto>(await doctorRepository.GetByIdAsync(
            id: request.DoctorId ?? throw new NotFoundException("Doctor is not found"), ignoreQueryFilters: true,
            enableTracking: false, cancellationToken: cancellationToken));
    }
}