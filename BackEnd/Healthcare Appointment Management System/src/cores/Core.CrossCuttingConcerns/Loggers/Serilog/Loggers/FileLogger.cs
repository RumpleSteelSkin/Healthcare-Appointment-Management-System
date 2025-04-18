﻿using System.Text;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.CrossCuttingConcerns.Loggers.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Loggers.Serilog.ServiceBase;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Core.CrossCuttingConcerns.Loggers.Serilog.Loggers;

public class FileLogger : LoggerService
{
    public FileLogger(IConfiguration configuration)
    {
        var logConfiguration = configuration
            .GetSection("SerilogLogConfigurations:FileLogConfiguration")
            .Get<FileLogConfiguration>();

        if (logConfiguration == null || string.IsNullOrEmpty(logConfiguration.FolderPath))
            throw new NotFoundException("Log path not found");

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), logConfiguration.FolderPath);
        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        Logger = new LoggerConfiguration()
            .WriteTo.File(
                Path.Combine(folderPath, "log-.txt"),
                rollingInterval: RollingInterval.Day,
                retainedFileTimeLimit: TimeSpan.FromDays(30),
                fileSizeLimitBytes: 5_000_000,
                encoding: Encoding.UTF8,
                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            )
            .CreateLogger();
    }
}