using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Add;

public class DoctorAddCommand : IRequest<string>, ITransactional, IRoleExists,ILoggableRequest
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Specialty { get; set; }
    public Guid? HospitalId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];
}