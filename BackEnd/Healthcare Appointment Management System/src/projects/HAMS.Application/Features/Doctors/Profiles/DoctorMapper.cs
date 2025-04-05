using AutoMapper;
using HAMS.Application.Features.Doctors.Commands.Add;
using HAMS.Application.Features.Doctors.Commands.Update;
using HAMS.Application.Features.Doctors.Queries.GetAll;
using HAMS.Application.Features.Doctors.Queries.GetById;
using HAMS.Domain.Models;

namespace HAMS.Application.Features.Doctors.Profiles;

public class DoctorMapper : Profile
{
    public DoctorMapper()
    {
        CreateMap<DoctorAddCommand, Doctor>();
        CreateMap<DoctorUpdateCommand, Doctor>();

        CreateMap<Doctor, DoctorGetAllQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(x => x.HospitalName, opt => opt.MapFrom(x => x.Hospital!.Name));

        CreateMap<Doctor, DoctorGetByIdQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"))
            .ForMember(x => x.HospitalName, opt => opt.MapFrom(x => x.Hospital!.Name));
    }
}