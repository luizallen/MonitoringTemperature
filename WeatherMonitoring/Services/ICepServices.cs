using System.Threading.Tasks;
using WeatherMonitoring.Domain.Models;

namespace WeatherMonitoring.Api.Services
{
    public interface ICepServices
    {
        Task<City> GetCityByCep(int cep);
    }
}