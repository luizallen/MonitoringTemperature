using Microsoft.Extensions.Configuration;
using SimpleInjector;
using WeatherMonitoring.Infrastructure.Repositories.CitiesRepository;
using WeatherMonitoring.Infrastructure.Repositories.SqlClientFactory;

namespace WeatherMonitoring.Api.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Load(Container container, IConfiguration configuration)
        {
            container.Register<ISqlClientFactory>(() => new SqlClientFactory(configuration.GetConnectionString("DataBase")));
            container.Register<ICitiesRepository, CitiesRepository>();
        }
    }
}
