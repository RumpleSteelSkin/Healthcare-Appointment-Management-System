using Core.Application.Pipelines.Transactional;
using MediatR;

namespace HAMS.Application.Features.Authentication.Commands.DeleteUser;

public class DeleteUserCommand : IRequest<string>, ITransactional
{
    public Guid userId { get; set; }
}