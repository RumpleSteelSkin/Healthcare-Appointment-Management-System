using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.CrossCuttingConcerns.Loggers.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Loggers.Serilog.ServiceBase;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

namespace Core.CrossCuttingConcerns.Loggers.Serilog.Loggers;

public class MsSqlLogger : LoggerService
{
    public MsSqlLogger(IConfiguration configuration)
    {
        var logConfig = configuration.GetSection("SerilogLogConfigurations:MsSqlConfiguration")
            .Get<MsSqlConfiguration>();

        if (logConfig?.ConnectionStrings == null ||
            !logConfig.ConnectionStrings.TryGetValue(
                configuration.GetSection("ConnectionStringsSelector").Get<string>()!, out var value))
            throw new NotFoundException("MsSqlConfiguration not found!");

        Logger = new LoggerConfiguration().WriteTo.MSSqlServer(value,
            new MSSqlServerSinkOptions
                { TableName = logConfig.TableName, AutoCreateSqlTable = logConfig.AutoCreateSqlTable }).CreateLogger();
    }
}