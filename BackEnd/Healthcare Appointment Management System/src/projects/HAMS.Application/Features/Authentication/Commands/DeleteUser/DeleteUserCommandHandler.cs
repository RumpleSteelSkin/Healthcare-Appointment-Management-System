using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using HAMS.Application.Features.Appointment.Commands.DeleteRangeByUserId;
using HAMS.Application.Features.Patients.Commands.Delete;
using HAMS.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HAMS.Application.Features.Authentication.Commands.DeleteUser;

public class DeleteUserCommandHandler(UserManager<User> userManager, IMediator mediator)
    : IRequestHandler<DeleteUserCommand, string>
{
    public async Task<string> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        User? user = await userManager.FindByIdAsync(request.userId.ToString()) ??
                     throw new NotFoundException("User not found");
        var rolesForUser = await userManager.GetRolesAsync(user);
        if (rolesForUser.Any())
            foreach (var item in rolesForUser.ToList())
                await userManager.RemoveFromRoleAsync(user, item);
        await userManager.DeleteAsync(user);
        await mediator.Send(new PatientDeleteCommand { PatientId = request.userId }, cancellationToken);
        await mediator.Send(new AppointmentDeleteRangeByUserIdCommand { userId = request.userId }, cancellationToken);
        return "User is deleted";
    }
}