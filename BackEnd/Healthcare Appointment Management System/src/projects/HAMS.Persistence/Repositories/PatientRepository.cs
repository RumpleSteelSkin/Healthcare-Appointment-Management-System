using Core.Persistence.Repositories;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using HAMS.Persistence.Contexts;

namespace HAMS.Persistence.Repositories;

public class PatientRepository(BaseDbContext context) : EntityFrameworkRepositoryBase<Patient, Guid, BaseDbContext>(context), IPatientRepository;