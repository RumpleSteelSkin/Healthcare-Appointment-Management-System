﻿using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactional;
using HAMS.Application.Constants;
using MediatR;

namespace HAMS.Application.Features.Doctors.Commands.Delete;

public class DoctorDeleteCommand : IRequest<string>,ITransactional,IRoleExists,ILoggableRequest,ICacheRemoverRequest
{
    public Guid DoctorId { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];

    public string? CacheKey => null;

    public string? CacheGroupKey => GeneralCacheGroupKeys.Doctor;
}