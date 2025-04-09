using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Authentication.Queries.GetUserDetailById;

public class GetUserDetailByIdCommandHandler(UserManager<User> userManager, IPatientRepository patientRepository)
    : IRequestHandler<GetUserDetailByIdCommand, GetUserDetailByIdCommandResponseDto>
{
    public async Task<GetUserDetailByIdCommandResponseDto> Handle(GetUserDetailByIdCommand request,
        CancellationToken cancellationToken)
    {
        var user = userManager.Users.FirstOrDefault(x => x.Id == request.UserId);
        if (user is null)
            throw new Exception("User not found");
        return new GetUserDetailByIdCommandResponseDto
        {
            BirthDate = (await patientRepository.GetByIdAsync(request.UserId ?? throw new Exception("User not found"),
                             cancellationToken: cancellationToken) ??
                         null!).BirthDate,
            Email = user.Email,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
        };
    }
}