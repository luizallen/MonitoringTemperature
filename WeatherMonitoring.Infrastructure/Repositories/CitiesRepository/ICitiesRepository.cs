using System;
using System.Threading.Tasks;
using WeatherMonitoring.Domain.Models;

namespace WeatherMonitoring.Infrastructure.Repositories.CitiesRepository
{
    public interface ICitiesRepository
    {
        Task<City> GetCity(Guid id);
        Task CreateCity(string cityName);
        Task DeleteCity(City city);
    }
}