using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Delete;

public class PatientDeleteCommand : IRequest<string> , IRoleExists, ITransactional, ILoggableRequest
{
    public Guid? PatientId { get; set; }
    public string[] Roles => [GeneralOperationClaims.User, GeneralOperationClaims.Admin];
}