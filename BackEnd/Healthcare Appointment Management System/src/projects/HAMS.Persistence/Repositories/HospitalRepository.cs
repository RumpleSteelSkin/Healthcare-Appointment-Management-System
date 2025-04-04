using Core.Persistence.Repositories;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using HAMS.Persistence.Contexts;

namespace HAMS.Persistence.Repositories;

public class HospitalRepository(BaseDbContext context) : EntityFrameworkRepositoryBase<Hospital, Guid, BaseDbContext>(context), IHospitalRepository;