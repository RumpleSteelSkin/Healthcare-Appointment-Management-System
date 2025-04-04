using Core.Persistence.Repositories;
using HAMS.Domain.Models;

namespace HAMS.Application.Services.Repositories;

public interface IHospitalRepository : IAsyncRepository<Hospital, Guid>;