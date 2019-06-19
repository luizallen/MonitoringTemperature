using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherMonitoring.Domain.Models;
using WeatherMonitoring.Infrastructure.HttpClients;

namespace WeatherMonitoring.Api.Services
{
    public class CepServices : ICepServices
    {
        public IHttpClientWrapper HttpClientWrapper { get; }

        public string ApiCepUrl { get; }

        public CepServices(
            IHttpClientWrapper httpClientWrapper,
            string apiCepUrl)
        {
            HttpClientWrapper = httpClientWrapper ?? throw new ArgumentNullException(nameof(httpClientWrapper));
            ApiCepUrl = apiCepUrl ?? throw new ArgumentNullException(nameof(apiCepUrl));
        }

        public async Task<City> GetCityByCep(int cep)
        {
            var requestMessage 
                = new HttpRequestMessage(HttpMethod.Get, $"{ApiCepUrl}{cep}/json");

            var city = await HttpClientWrapper.SendAsync<City>(requestMessage);

            return city;
        }
    }
}
