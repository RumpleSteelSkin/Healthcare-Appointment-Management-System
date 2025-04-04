using HAMS.Application.Services.Repositories;
using HAMS.Persistence.Contexts;
using HAMS.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HAMS.Persistence.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        #region Entity Framework Services

        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString(configuration.GetSection("ConnectionStringsSelector")
                    .Get<string>()!)));

        #endregion

        #region Repository Interface Define

        services.AddScoped<IAppointmentRepository, AppointmentRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IHospitalRepository, HospitalRepository>();

        #endregion

        return services;
    }
}