using Serilog;

namespace Core.Helpers;

/// <summary>Provides a shared, thread-safe Serilog logger instance for the entire project.</summary>
public static class LoggerHelper
{
    public static readonly ILogger Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()                                                // Log everything from Debug level and above
        .WriteTo.Console()                                                   // Print logs to terminal during test run
        .WriteTo.File("logs/ats-.log", rollingInterval: RollingInterval.Day) // Also save logs to a rolling daily file
        .CreateLogger();
}