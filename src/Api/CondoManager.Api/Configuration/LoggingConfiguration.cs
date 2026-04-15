using Serilog;

namespace API.Configuration;

public static class LoggingConfiguration
{
    public static WebApplicationBuilder AddLogging(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
           .Enrich.FromLogContext()
           .CreateLogger();

        builder.Host.UseSerilog();

        return builder;
    }
}
