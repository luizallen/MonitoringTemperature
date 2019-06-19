using Braspag.FluentQueryBuilder;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WeatherMonitoring.Domain.Models;
using WeatherMonitoring.Infrastructure.Dtos;
using WeatherMonitoring.Infrastructure.Repositories.SqlClientFactory;

namespace WeatherMonitoring.Infrastructure.Repositories.CitiesRepository
{
    public class CitiesRepository : ICitiesRepository
    {
        public ISqlClientFactory SqlClientFactory { get; }

        public CitiesRepository(ISqlClientFactory sqlClientFactory)
        {
            SqlClientFactory = sqlClientFactory ?? throw new ArgumentNullException(nameof(sqlClientFactory));
        }

        public async Task<City> GetCity(Guid id)
        {
            var query = new SelectBuilder()
                .Select("Id, Name, Active")
                .From("Cities")
                .Where("Id = @id")
                .Build();

            using (SqlConnection connection = new SqlConnection(SqlClientFactory.GetConnection()))
            {
                connection.Open();
                var cities = await connection.QueryAsync<City>(query, id);

                return cities.FirstOrDefault();
            }
        }

        public async Task CreateCity(string cityName)
        {
            var city = CreateCityDto(cityName, true);

            using (SqlConnection connection = new SqlConnection(SqlClientFactory.GetConnection()))
            {
                connection.Open();
                await connection.InsertAsync(city);
            }
        }

        public async Task DeleteCity(City city)
        {
            var cityDto = CreateCityDto(city.Id, city.Name, false);

            using (SqlConnection connection = new SqlConnection(SqlClientFactory.GetConnection()))
            {
                connection.Open();
                await connection.UpdateAsync(cityDto);
            }
        }

        private CityDto CreateCityDto(string cityName, bool active)
            => new CityDto(cityName, active);

        private CityDto CreateCityDto(Guid id ,string cityName, bool active)
            => new CityDto(id, cityName, active);
    }
}
