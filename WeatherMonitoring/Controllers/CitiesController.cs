using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherMonitoring.Api.Services;
using WeatherMonitoring.Domain.Extensions;
using WeatherMonitoring.Infrastructure.Repositories.CitiesRepository;

namespace WeatherMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        public ICitiesRepository CitiesRepository { get; }

        public ICepServices CepServices { get; }

        public CitiesController(
            ICitiesRepository citiesRepository,
            ICepServices cepServices)
        {
            CitiesRepository = citiesRepository ?? throw new ArgumentNullException(nameof(citiesRepository));
            CepServices = cepServices ?? throw new ArgumentNullException(nameof(cepServices));
        }
        
        [HttpPost]
        [Route("{cityName}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            if (cityName.IsNullOrWhiteSpaces())
                return BadRequest("Invalid City Name");

            var createdCity = await CitiesRepository.CreateCity(cityName);

            return Ok(createdCity);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCity(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid City Id");

            var city = await CitiesRepository.GetCity(id);

            if (city == null)
                return NotFound("City not found");

            return Ok(city);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCity(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Invalid City Id");

            var city = await CitiesRepository.GetCity(id);

            if (city == null)
                return NotFound("City not found");

            await CitiesRepository.DeleteCity(city);

            return Ok();
        }

        [HttpPost]
        [Route("by_cep/{cep}")]
        public async Task<IActionResult> AddCityByCep(int cep)
        {
            if (cep < 10000000)
                return BadRequest("Invalid Cep");

            var city = await CepServices.GetCityByCep(cep);

            if (city == null)
                return BadRequest("City does not exists in this zip code");

            var createdCity = await CitiesRepository.CreateCity(city.Name);

            return Ok(createdCity);
        }
    }
}
