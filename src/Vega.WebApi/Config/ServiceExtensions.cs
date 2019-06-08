using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega.Data.Context;

namespace Vega.WebApi.Config
{
    public static class ServiceExtensions
    {
        public static IConfiguration Configuration { get; }
        
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Default")));
            
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration()
                    .GetConnectionString("Default");
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                
                optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Vega.Data"));

                return new ApplicationDbContext(optionsBuilder.Options);
            });
        }
    }
}