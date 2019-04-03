using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Vega.Data.Context;

namespace Vega.WebApi.Config
{
    /*
     * Problem
     * If DbContext is in a separate project – class library project.
     * to add new migration and update database, may encounter this error:
     *
     * -- Unable to create an object of type ‘CodingBlastDbContext’.
     * -- Add an implementation of ‘IDesignTimeDbContextFactory’ to the project,
     * -- or see https://go.microsoft.com/fwlink/?linkid=851728
     * -- for additional patterns supported at design time.
     *
     * Solution
     * Add a class that implements IDesignTimeDbContextFactory inside of Web project.
     *
     * Navigate to Database project and run the following from command line:
     * > dotnet ef migrations add <migration-name> -s ../<web-project-folder>/
     * > dotnet ef database update -s ../<web-project-folder>/
     *
     * -s stands for startup project and ../<web-project-folder>/ is the location of my web/startup project.
     *
     * Github page of this solution: https://github.com/Ibro/DesignTimeDbContextFactory
     */
    
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Get DbContext from DI system
            var resolver = new DependencyResolver
            {
                CurrentDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../Vega.WebApi")
            };
        
            return resolver.ServiceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        }

//        public ApplicationDbContext CreateDbContext(string[] args)
//        {
//            var configuration = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();
//
//            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
//            builder.UseSqlServer(configuration.GetConnectionString("Default"));
//            
//            return new ApplicationDbContext(builder.Options);
//        }
    }
}