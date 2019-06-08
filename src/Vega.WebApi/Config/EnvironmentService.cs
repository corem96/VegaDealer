using System;
using Vega.Data.Context;

namespace Vega.WebApi.Config
{
    public class EnvironmentService : IEnvironmentService
    {
        public string EnvironmentName { get; set; }

        public EnvironmentService()
        {
            EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
                              ?? "Production";
        }
    }
}