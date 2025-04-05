using AutoMapper;
using HAMS.Application.Features.Hospitals.Commands.Add;
using HAMS.Application.Features.Hospitals.Commands.Update;
using HAMS.Application.Features.Hospitals.Queries.GetAll;
using HAMS.Application.Features.Hospitals.Queries.GetById;
using HAMS.Domain.Models;

namespace HAMS.Application.Features.Hospitals.Profiles;

public class HospitalMapper : Profile
{
    public HospitalMapper()
    {
        CreateMap<Hospital, HospitalGetAllQueryResponseDto>();
        CreateMap<Hospital, HospitalGetByIdQueryResponseDto>();

        CreateMap<HospitalAddCommand, Hospital>();
        CreateMap<HospitalUpdateCommand, Hospital>();
    }
}