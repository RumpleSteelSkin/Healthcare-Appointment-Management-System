using AutoMapper;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HAMS.Application.Features.Authentication.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(UserManager<User> userManager, IMapper mapper)
    : IRequestHandler<GetAllUsersQuery, ICollection<GetAllUsersQueryResponseDto>>
{
    public async Task<ICollection<GetAllUsersQueryResponseDto>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        return mapper.Map<ICollection<GetAllUsersQueryResponseDto>>(
            await userManager.Users.ToListAsync(cancellationToken: cancellationToken));
    }
}