using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.UserRoles.Queries.GetByUserId;

public class UserRoleGetByUserIdQueryHandler(UserManager<User> userManager)
    : IRequestHandler<UserRoleGetByUserIdQuery, UserRoleGetByUserIdQueryResponseDto>
{
    public async Task<UserRoleGetByUserIdQueryResponseDto> Handle(UserRoleGetByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.UserId.ToString());

        if (user is null)
            throw new NotFoundException($"User with ID {request.UserId} not found!");
        
        return new UserRoleGetByUserIdQueryResponseDto()
        {
            Email = user.Email,
            Roles = await userManager.GetRolesAsync(user),
            UserName = user.UserName
        };
    }
}