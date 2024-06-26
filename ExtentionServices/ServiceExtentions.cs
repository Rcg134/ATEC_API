
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using ATEC_API.Data.Context;
using ATEC_API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ATEC_API.ExtentionServices
{
    public static class ServiceExtentions
    {
      #region CORS
       public static void ConfigureCors(this IServiceCollection services) =>
           services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy",
                                policy =>
                                {
                                    policy.AllowAnyOrigin()
                                          .AllowAnyHeader();
                                });
          });
       #endregion
      
      #region Logger
        public static void ConfigureLogger(this IServiceCollection services , IConfiguration configuration) 
        {
           var currentDirectory = Directory.GetCurrentDirectory();
           var logFilePath = configuration["Logging:LogFilePath"];
           var fullLogFilePath = Path.Combine(currentDirectory, logFilePath);

            // Ensure the directory exists
            var logDirectory = Path.GetDirectoryName(fullLogFilePath);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
                var logger = new LoggerConfiguration()
                  .WriteTo.Console()
                  .WriteTo.File(fullLogFilePath, rollingInterval: RollingInterval.Day)
                  .MinimumLevel
                  .Information()
                  .CreateLogger();
            Log.Logger = logger;
            services.AddSingleton<Serilog.ILogger>(logger);
          
        }
      #endregion
      
      #region Context
        public static void ConfigureDatabasesContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HrisContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("HRIS_Connection"));
            });
    
            services.AddDbContext<UserContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("CentralAccess_Connection"));
            });
        }
       #endregion

      #region HealthCheck
        public static void ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().
                    AddCheck<DatabaseHealthCheck>("custom-sql",HealthStatus.Unhealthy);; 
        }
       #endregion

    }



}