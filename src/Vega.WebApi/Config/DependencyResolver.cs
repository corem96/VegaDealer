using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vega.Data.Context;

namespace Vega.WebApi.Config
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; set; }
        public string CurrentDirectory { get; set; }

        public DependencyResolver()
        {
            // Set up Dependency Injection
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider = services.BuildServiceProvider();

        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register env and config services
            services.AddTransient<IEnvironmentService, EnvironmentService>();
            services.AddTransient<IConfigurationService, ConfigurationService>
                (provider => new ConfigurationService(provider.GetService<IEnvironmentService>())
                {
                    CurrentDirectory = CurrentDirectory
                });
            
            // Register DbContext class
            services.AddTransient(provider =>
            {
                var configService = provider.GetService<IConfigurationService>();
                var connectionString = configService.GetConfiguration().GetConnectionString(nameof(ApplicationDbContext));
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Vega.Data"));

                return new ApplicationDbContext(optionsBuilder.Options);
            });
        }
    }
}