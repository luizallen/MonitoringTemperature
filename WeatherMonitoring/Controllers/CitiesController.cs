using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WeatherMonitoring.Domain.Extensions;
using WeatherMonitoring.Infrastructure.Repositories.CitiesRepository;

namespace WeatherMonitoring.Api.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        public ICitiesRepository CitiesRepository { get; }

        public CitiesController(ICitiesRepository citiesRepository)
        {
            CitiesRepository = citiesRepository ?? throw new ArgumentNullException(nameof(citiesRepository));
        }
        
        [HttpPost]
        [Route("{cityName}")]
        public async Task<IActionResult> AddCity(string cityName)
        {
            if (cityName.IsNullOrWhiteSpaces())
                return BadRequest("Invalid City Name");

            await CitiesRepository.CreateCity(cityName);

            return Ok();
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
    }
}
