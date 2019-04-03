using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Vega.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder()
//                .ConfigureAppConfiguration((context, config) =>
//                {
//                    config.SetBasePath(Directory.GetCurrentDirectory())
////                        .AddJsonFile("config.json", true)
//                        .AddEnvironmentVariables();
//                })
                .UseSetting("DesignTime", "true")
                .UseStartup<Startup>();
    }
}