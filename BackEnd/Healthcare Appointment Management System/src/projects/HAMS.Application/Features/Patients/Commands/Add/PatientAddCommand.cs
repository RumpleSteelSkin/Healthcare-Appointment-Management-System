using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Commands.Add;

public class PatientAddCommand : IRequest<string>, IRoleExists, ITransactional, ILoggableRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public string[] Roles => [GeneralOperationClaims.User, GeneralOperationClaims.Admin];
}