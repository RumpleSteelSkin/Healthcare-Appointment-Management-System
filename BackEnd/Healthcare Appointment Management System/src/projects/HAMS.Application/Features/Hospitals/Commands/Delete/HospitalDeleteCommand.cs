using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Hospitals.Commands.Delete;

public class HospitalDeleteCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public Guid Id { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin];
}