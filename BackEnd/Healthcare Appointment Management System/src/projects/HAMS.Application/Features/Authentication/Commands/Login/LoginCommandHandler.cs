﻿using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Services.JwtServices;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler(UserManager<User> userManager, IJwtService jwtService)
    : IRequestHandler<LoginCommand, AccessTokenDto>
{
    public async Task<AccessTokenDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        if (request.UserNameOrEmail is null)
            throw new NotFoundException("Email cannot be null.");

        User? emailUser = await userManager.FindByEmailAsync(request.UserNameOrEmail) ??
                          await userManager.FindByNameAsync(request.UserNameOrEmail);

        if (emailUser is null)
            throw new NotFoundException("No user found with the specified email address or username.");

        if (request.Password is null)
            throw new NotFoundException("Password cannot be null.");

        if (await userManager.CheckPasswordAsync(emailUser, request.Password) is false)
            throw new BusinessException("Email/UserName or password is not correct. Please try again.");

        return await jwtService.CreateTokenAsync(emailUser);
    }
}