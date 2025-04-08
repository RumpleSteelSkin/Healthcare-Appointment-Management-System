using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Authentication.Commands.UpdateUser;

public class UpdateUserCommandHandler(IMapper mapper, UserManager<User> userManager)
    : IRequestHandler<UpdateUserCommand, string>
{
    public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id.ToString());
        if (user == null)
            throw new NotFoundException("User not found!");
        mapper.Map(request, user); // request'den user'a eşleme
        await userManager.UpdateAsync(user);
        return "User is updated";
    }
}