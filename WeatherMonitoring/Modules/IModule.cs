using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace WeatherMonitoring.Api.Modules
{
    public interface IModule
    {
        void Load(Container container, IConfiguration configuration);
    }
}
