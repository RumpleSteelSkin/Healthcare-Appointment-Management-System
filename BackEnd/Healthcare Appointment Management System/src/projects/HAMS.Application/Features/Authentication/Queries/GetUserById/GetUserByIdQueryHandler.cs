using AutoMapper;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HAMS.Application.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQueryHandler(UserManager<User> userManager, IMapper mapper)
    : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResponseDto>
{
    public async Task<GetUserByIdQueryResponseDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return mapper.Map<GetUserByIdQueryResponseDto>(
            await userManager.Users.FirstOrDefaultAsync(x => x.Id == request.UserId,
                cancellationToken: cancellationToken));
    }
}