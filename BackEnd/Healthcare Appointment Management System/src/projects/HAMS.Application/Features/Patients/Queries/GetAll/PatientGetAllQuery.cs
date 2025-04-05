using Core.Application.Pipelines.Authorization;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Patients.Queries.GetAll;

public class PatientGetAllQuery : IRequest<ICollection<PatientGetAllQueryResponseDto>>, IRoleExists
{
    public string[] Roles => [GeneralOperationClaims.Admin, GeneralOperationClaims.User];
}