using System.Reflection;
using Bogus;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Performance;
using Core.Application.Pipelines.Transactional;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Loggers.Serilog.Loggers;
using Core.CrossCuttingConcerns.Loggers.Serilog.ServiceBase;
using FluentValidation;
using HAMS.Application.Features.Appointment.Rules;
using HAMS.Application.Features.Doctors.Rules;
using HAMS.Application.Features.Hospitals.Rules;
using HAMS.Application.Features.Patients.Rules;
using Microsoft.Extensions.DependencyInjection;
using HAMS.Application.Services.JwtServices;

namespace HAMS.Application.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region AutoMapper Services

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        #endregion

        #region JWT Services

        services.AddScoped<IJwtService, JwtService>();

        #endregion

        #region Serilog Services

        services.AddTransient<LoggerService, MsSqlLogger>();
        // services.AddTransient<LoggerService, FileLogger>();

        #endregion

        #region Fluent Validation Services

        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);

        #endregion

        #region Bogus Services

        services.AddScoped(typeof(Faker<>));

        #endregion

        #region Business Rules Services

        services.AddScoped<PatientBusinessRules>();
        services.AddScoped<HospitalBusinessRules>();
        services.AddScoped<DoctorBusinessRules>();
        services.AddScoped<AppointmentBusinessRules>();

        #endregion

        #region MediatR Services

        services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

            //Pipeline Registration
            opt.AddOpenBehavior(typeof(ValidationPipeline<,>));
            opt.AddOpenBehavior(typeof(AuthorizationPipeline<,>));
            opt.AddOpenBehavior(typeof(TransactionalPipeline<,>));
            opt.AddOpenBehavior(typeof(PerformancePipeline<,>));
            opt.AddOpenBehavior(typeof(LoggingPipeline<,>));
            opt.AddOpenBehavior(typeof(CacheRemovePipeline<,>));
            opt.AddOpenBehavior(typeof(AddCachePipeline<,>));
        });

        #endregion
        
        return services;
    }
}