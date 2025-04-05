using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Queries.GetById;

public class PatientGetByIdQuery : IRequest<PatientGetByIdQueryResponseDto>, IRoleExists
{
    public Guid? PatientId { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin, GeneralOperationClaims.User];
}