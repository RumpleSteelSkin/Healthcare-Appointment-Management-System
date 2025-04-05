using AutoMapper;
using HAMS.Application.Features.Patients.Commands.Add;
using HAMS.Application.Features.Patients.Commands.Update;
using HAMS.Application.Features.Patients.Queries.GetAll;
using HAMS.Application.Features.Patients.Queries.GetById;
using HAMS.Domain.Models;

namespace HAMS.Application.Features.Patients.Profiles;

public class PatientMapper : Profile
{
    public PatientMapper()
    {
        CreateMap<PatientAddCommand, Patient>();
        CreateMap<PatientUpdateCommand, Patient>();

        CreateMap<Patient, PatientGetByIdQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
        CreateMap<Patient, PatientGetAllQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
    }
}