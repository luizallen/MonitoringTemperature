using Microsoft.Extensions.Configuration;
using SimpleInjector;
using System.Net.Http;
using WeatherMonitoring.Infrastructure.HttpClients;
using WeatherMonitoring.Infrastructure.Repositories.CitiesRepository;
using WeatherMonitoring.Infrastructure.Repositories.SqlClientFactory;
using WeatherMonitoring.Infrastructure.Serializers;

namespace WeatherMonitoring.Api.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            container.Register<ISqlClientFactory>(() => new SqlClientFactory(configuration.GetConnectionString("DataBase")));
            container.Register<ICitiesRepository, CitiesRepository>();

            container.Register<ICustomSerialization, CustomJsonConverter>();

            container.Register<IHttpClientWrapper, HttpClientWrapper>();
            container.RegisterDecorator<IHttpClientWrapper, HttpClientWrapperWithErrorHandler>();

            container.Register(() => new HttpClient(), Lifestyle.Singleton);
        }
    }
}
