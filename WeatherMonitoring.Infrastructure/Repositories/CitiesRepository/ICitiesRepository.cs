using System;
using System.Threading.Tasks;
using WeatherMonitoring.Domain.Models;
using WeatherMonitoring.Infrastructure.Dtos;

namespace WeatherMonitoring.Infrastructure.Repositories.CitiesRepository
{
    public interface ICitiesRepository
    {
        Task<City> GetCity(Guid id);
        Task<CityDto> CreateCity(string cityName);
        Task DeleteCity(City city);
    }
}