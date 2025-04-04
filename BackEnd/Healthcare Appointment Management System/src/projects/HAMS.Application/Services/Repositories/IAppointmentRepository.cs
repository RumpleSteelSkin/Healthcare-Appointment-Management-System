using Core.Persistence.Repositories;
using HAMS.Domain.Models;

namespace HAMS.Application.Services.Repositories;

public interface IAppointmentRepository : IAsyncRepository<Appointment, Guid>;