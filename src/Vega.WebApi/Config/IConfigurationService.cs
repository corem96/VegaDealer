using Microsoft.Extensions.Configuration;

namespace Vega.Data.Context
{
    public interface IConfigurationService
    {
        IConfiguration GetConfiguration();
    }
}