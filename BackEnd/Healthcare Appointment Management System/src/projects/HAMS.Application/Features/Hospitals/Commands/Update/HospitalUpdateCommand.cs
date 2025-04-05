using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Update;

public class HospitalUpdateCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}