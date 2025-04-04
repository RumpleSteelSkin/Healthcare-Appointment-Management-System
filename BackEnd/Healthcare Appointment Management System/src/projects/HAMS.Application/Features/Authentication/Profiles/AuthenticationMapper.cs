using AutoMapper;
using HAMS.Application.Features.Authentication.Queries.GetAllUsers;
using HAMS.Application.Features.Authentication.Queries.GetUserById;
using HAMS.Application.Features.Authentication.Queries.GetUsersByRoleId;
using HAMS.Domain.Models;

namespace HAMS.Application.Features.Authentication.Profiles;

public class AuthenticationMapper : Profile
{
    public AuthenticationMapper()
    {
        CreateMap<User, GetAllUsersQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));

        CreateMap<User, GetUserByIdQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));

        CreateMap<User, GetUsersByRoleIdQueryResponseDto>()
            .ForMember(x => x.FullName, opt => opt.MapFrom(x => $"{x.FirstName} {x.LastName}"));
    }
}