using Core.Persistence.Repositories;
using HAMS.Application.Services.Repositories;
using HAMS.Domain.Models;
using HAMS.Persistence.Contexts;

namespace HAMS.Persistence.Repositories;

public class AppointmentRepository(BaseDbContext context) : EntityFrameworkRepositoryBase<Appointment, Guid, BaseDbContext>(context), IAppointmentRepository;