using Core.Persistence.Repositories;
using HAMS.Domain.Models;

namespace HAMS.Application.Services.Repositories;

public interface IPatientRepository : IAsyncRepository<Patient, Guid>;