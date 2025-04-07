using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Patients.Commands.Add;
using HAMS.Application.Services.JwtServices;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Authentication.Commands.Register;

public class RegisterCommandHandler(UserManager<User> userManager, IJwtService jwtService, IMediator mediator)
    : IRequestHandler<RegisterCommand, AccessTokenDto>
{
    public async Task<AccessTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            throw new BusinessException("Email is required.");
        if (string.IsNullOrWhiteSpace(request.Password))
            throw new BusinessException("Password is required.");
        if (string.IsNullOrWhiteSpace(request.FirstName))
            throw new BusinessException("First name is required.");
        if (string.IsNullOrWhiteSpace(request.LastName))
            throw new BusinessException("Last name is required.");
        if (string.IsNullOrWhiteSpace(request.UserName))
            throw new BusinessException("Username is required.");

        if (await userManager.FindByEmailAsync(request.Email) is not null)
            throw new BusinessException("A user with this email address already exists.");

        if (await userManager.FindByNameAsync(request.UserName) is not null)
            throw new BusinessException("A user with this username already exists.");

        Guid identifierUser = Guid.NewGuid();
        User user = new()
        {
            Id = identifierUser,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.UserName,
            Email = request.Email,
        };

        IdentityResult result = await userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            throw new BusinessException(
                $"User registration failed: {string.Join("; ", result.Errors.Select(e => e.Description))}");

        await mediator.Send(new PatientAddCommand()
        {
            Id = identifierUser, FirstName = user.FirstName, LastName = user.LastName, BirthDate = request.BirthDate
        }, cancellationToken);

        AccessTokenDto token = await jwtService.CreateTokenAsync(user);

        return token;
    }
}