using Microsoft.Extensions.Configuration;
using SimpleInjector;
using WeatherMonitoring.Api.Services;
using WeatherMonitoring.Infrastructure.HttpClients;

namespace WeatherMonitoring.Api.Modules
{
    public class ApiModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            container.Register<ICepServices>(() => new CepServices(container.GetInstance<IHttpClientWrapper>(),
                configuration.GetValue<string>("ApiCepUrl")));
        }
    }
}
